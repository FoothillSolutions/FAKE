[<RequireQualifiedAccess>]
module Fake.Tools.DynamicCrm

open Fake.Core
open Fake.IO
open Fake.IO.FileSystemOperators
open System
open System.Runtime.CompilerServices
open Microsoft.PowerPlatform.Dataverse.Client
open Microsoft.Crm.Sdk.Messages

[<assembly: InternalsVisibleTo("Fake.Core.UnitTests")>]
do ()

/// Specify which action Solution Packager should be invoked with
type SolutionPackagerAction =
    | Extract
    | Pack
    override s.ToString() =
        match s with
        | Extract -> "/a:Extract"
        | Pack -> "/a:Pack"

/// Specify Package Type for usage with Solution Packager
type PackageType =
    | Unmanaged
    | Managed
    | Both
    override p.ToString() =
        match p with
        | Unmanaged -> "/p:Unmanaged"
        | Managed -> "/p:Managed"
        | Both -> "/p:Both"

/// Parameters for invoking Solution Packager
type SolutionPackagerParams =
    {
      /// Action to start, either pack or extract
      Action: SolutionPackagerAction
      /// Path to solution that should be packed or extracted
      ZipFile: string
      /// PackageType for packing solution, either managed, unmanaged or both
      PackageType: PackageType
      /// Path to SolutionPackager tool
      SolutionPackagerToolPath: string
      /// Timeout for calls
      TimeOut: TimeSpan
      /// Folder for output of calls
      Folder: string }

/// Default values for invoking Solution Packager
let solutionPackagerDefaults =
    { SolutionPackagerToolPath = IO.Directory.GetCurrentDirectory() @@ "tools" @@ "SolutionPackager.exe"
      TimeOut = TimeSpan.FromMinutes 1.0
      Action = Extract
      ZipFile = ""
      PackageType = Both
      Folder = "." }

/// Parameters for executing Dynamics CRM Helper functions
type DynamicsCrmParams =
    {
      /// Url of CRM Organization / Discovery Service URL if using AllOrganizations
      Url: string
      /// Client id to use for credentials
      ClientId: string
      /// Client secret to use for credentials
      ClientSecret: string
      /// Working Directory for actions, can be used to influence storage locations of files
      WorkingDirectory: string
      /// Set for specifying output file name when exporting solution or input solution name when importing
      FileName: string
      /// Set for specifying unique name of solution when exporting single solution
      Solution: string
      /// Specify, whether solution should be exported as managed or unmanaged
      Managed: bool }

/// Default values for Dynamics CRM
let dynamicsCrmDefaults =
    { Url = ""
      ClientId = ""
      ClientSecret = ""
      WorkingDirectory = ""
      FileName = ""
      Solution = ""
      Managed = false }


/// Get Crm service using dynamic params.
/// ## Parameters
///
///  - `dynamicCrmParams` - Dynamics crm params
let internal getService (dynamicCrmParams: DynamicsCrmParams) =
    try
        let service = new ServiceClient(new Uri(dynamicCrmParams.Url),dynamicCrmParams.ClientId,dynamicCrmParams.ClientSecret, true);

        if not service.IsReady then
            failwith (sprintf "Could not connect, Error: %s" service.LastError)

        service
    with   
    | ex -> failwith (sprintf "Error while creating organization service: %A" ex.Message)

/// Publishes all customizations in an organization
/// ## Parameters
///
///  - `dynamicCrmParams` - Dynamics crm params
let publishAllCustomizations (dynamicCrmParams : DynamicsCrmParams -> DynamicsCrmParams) =
    use __ = Trace.traceTask "Publish All Customizations" ""
    let parameters = dynamicCrmParams dynamicsCrmDefaults
    let service = getService parameters
    let publishRequest = new PublishAllXmlRequest()
    service.Execute(publishRequest) |> ignore

/// Exports solution
/// ## Parameters
///
///  - `dynamicCrmParams` - Dynamics crm params
let exportSolution (dynamicCrmParams : DynamicsCrmParams -> DynamicsCrmParams) =
    use __ = Trace.traceTask "Exporting Solution" ""
    let parameters = dynamicCrmParams dynamicsCrmDefaults
    let service = getService parameters

    if parameters.Solution = "" then
        failwith "Please specify a solution name!"

    let exportSolutionRequest = new ExportSolutionRequest( Managed = parameters.Managed, SolutionName = parameters.Solution )
    
    try
        let response = service.Execute(exportSolutionRequest) :?> ExportSolutionResponse
        let fileName = 
            match parameters.FileName = "" with
            | true -> parameters.Solution
            | false -> parameters.FileName
        let path = parameters.WorkingDirectory @@ fileName + ".zip"
        File.writeBytes path response.ExportSolutionFile
    with
    | ex -> failwith ex.Message
            
/// Import solution
/// ## Parameters
///
///  - `dynamicCrmParams` - Dynamics crm params
let importSolution (dynamicCrmParams : DynamicsCrmParams -> DynamicsCrmParams) =
    use __ = Trace.traceTask "Importing Solution" ""
    let parameters = dynamicCrmParams dynamicsCrmDefaults
    let service = getService parameters
    if not (File.exists parameters.FileName) then
        failwith (sprintf "File %A does not exist" parameters.FileName)
    let file = File.readAsBytes parameters.FileName
    let importSolutionRequest = new ImportSolutionRequest( CustomizationFile = file, PublishWorkflows = true )
    service.Execute(importSolutionRequest) |> ignore
    dynamicCrmParams

/// Execute the solution packager tool
/// ## Parameters
///
///  - `solutionPackagerParams` - Parameters for solution packager
let solutionPackager (solutionPackagerParams : SolutionPackagerParams -> SolutionPackagerParams) = 
    use __ = Trace.traceTask "Executing Solution Packager" ""
    let parameters = solutionPackagerParams solutionPackagerDefaults
    if not (File.exists(parameters.ZipFile)) then
        failwith (sprintf "File at path %A does not exist!" parameters.ZipFile)
    let arguments = sprintf "%s %s /z:\"%s\" /f:\"%s\"" (parameters.Action.ToString()) (parameters.PackageType.ToString()) parameters.ZipFile parameters.Folder
    
    if String.IsNullOrWhiteSpace parameters.SolutionPackagerToolPath then
            failwith "No SolutionPackager.exe filename was given."

    if not (File.exists parameters.SolutionPackagerToolPath) then
        failwithf "Unable to find a valid instance of SolutionPackager.exe"
        
        let result = 
            CreateProcess.fromRawCommandLine parameters.SolutionPackagerToolPath arguments
            |> CreateProcess.withTimeout parameters.TimeOut
            |> Proc.run
        
        if result.ExitCode <> 0 then
            failwithf "Process exit code '%d' <> 0." result.ExitCode
        