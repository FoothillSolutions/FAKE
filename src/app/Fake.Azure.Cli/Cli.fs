module Fake.Azure.Cli

open System
open Fake.Core

    type AzCommands =
       | Account of string 
       | Acr of string 
       | Acs of string 
       | Ad of string 
       | Advisor of string 
       | Afd of string 
       | AiExamples of string 
       | Aks of string 
       | Alias of string 
       | Ams of string 
       | Apim of string 
       | Appconfig of string 
       | Appservice of string 
       | Arcappliance of string 
       | Aro of string 
       | Artifacts of string 
       | Attestation of string 
       | Automation of string 
       | Backup of string 
       | Baremetalinstance of string 
       | Batch of string 
       | Batchai of string 
       | Bicep of string 
       | Billing of string 
       | Blockchain of string 
       | Blueprint of string 
       | Boards of string 
       | Bot of string 
       | Cache of string 
       | Cdn of string 
       | CliTranslator of string 
       | Cloud of string 
       | CloudService of string 
       | Codespace of string 
       | Cognitiveservices of string 
       | Communication of string 
       | Config of string 
       | Configure of string 
       | Confluent of string 
       | Connectedk8s of string 
       | Connectedmachine of string 
       | Consumption of string 
       | Container of string 
       | Cosmosdb of string 
       | Costmanagement of string 
       | Csvmware of string 
       | Customlocation of string 
       | CustomProviders of string 
       | Databox of string 
       | Databoxedge of string 
       | Databricks of string 
       | Datafactory of string 
       | Datashare of string 
       | DedicatedHsm of string 
       | Demo of string 
       | Deployment of string 
       | Deploymentmanager of string 
       | DeploymentScripts of string 
       | Desktopvirtualization of string 
       | Devops of string 
       | Disk of string 
       | DiskAccess of string 
       | DiskEncryptionSet of string 
       | Dla of string 
       | Dls of string 
       | Dms of string 
       | Dt of string 
       | Eventgrid of string 
       | Eventhubs of string 
       | Extension of string 
       | Feature of string 
       | Feedback of string 
       | Find of string 
       | Footprint of string 
       | Functionapp of string 
       | Fzf of string 
       | Graph of string 
       | Group of string 
       | Guestconfig of string 
       | Hack of string 
       | Hanainstance of string 
       | Hdinsight of string 
       | Healthbot of string 
       | Healthcareapis of string 
       | HpcCache of string 
       | Identity of string 
       | Image of string 
       | ImportExport of string 
       | Interactive of string 
       | InternetAnalyzer of string 
       | Iot of string 
       | K8sconfiguration of string 
       | K8sConfiguration of string 
       | K8sExtension of string 
       | Keyvault of string 
       | Kusto of string 
       | Lab of string 
       | LocalContext of string 
       | Lock of string 
       | Logic of string 
       | Login of string 
       | Logout of string 
       | Maintenance of string 
       | Managedapp of string 
       | ManagedCassandra of string 
       | Managedservices of string 
       | Managementpartner of string 
       | Maps of string 
       | Mariadb of string 
       | Mesh of string 
       | Ml of string 
       | Monitor of string 
       | Mysql of string 
       | Netappfiles of string 
       | Network of string 
       | Next of string 
       | NotificationHub of string 
       | Offazure of string 
       | Openshift of string 
       | Peering of string 
       | Pipelines of string 
       | Policy of string 
       | Portal of string 
       | Postgres of string 
       | Powerbi of string 
       | Ppg of string 
       | Provider of string 
       | Providerhub of string 
       | Quantum of string 
       | Redis of string 
       | Redisenterprise of string 
       | Relay of string 
       | RemoteRenderingAccount of string 
       | Repos of string 
       | Reservations of string 
       | Resource of string 
       | ResourceMover of string 
       | Rest of string 
       | Role of string 
       | Sapmonitor of string 
       | Search of string 
       | Security of string 
       | SelfTest of string 
       | Sentinel of string 
       | Servicebus of string 
       | Sf of string 
       | Sig of string 
       | Signalr of string 
       | Snapshot of string 
       | SpatialAnchorsAccount of string 
       | SpringCloud of string 
       | Sql of string 
       | Ssh of string 
       | Sshkey of string 
       | StackHci of string 
       | Staticwebapp of string 
       | Storage of string 
       | Storagesync of string 
       | StreamAnalytics of string 
       | Support of string 
       | Synapse of string 
       | Tag of string 
       | Ts of string 
       | Tsi of string 
       | Upgrade of string 
       | Version of string 
       | Vm of string 
       | Vmss of string 
       | Vmware of string 
       | Webapp of string       

    let parse = function
         | Account str -> sprintf "account %s" str
         | Acr str -> sprintf "Acr %s" str 
         | Acs str -> sprintf "Acs %s" str 
         | Ad str -> sprintf "Ad %s" str 
         | Advisor str -> sprintf "Advisor %s" str 
         | Afd str -> sprintf "Afd %s" str 
         | AiExamples str -> sprintf "AiExamples %s" str 
         | Aks str -> sprintf "Aks %s" str 
         | Alias str -> sprintf "Alias %s" str 
         | Ams str -> sprintf "Ams %s" str 
         | Apim str -> sprintf "Apim %s" str 
         | Appconfig str -> sprintf "Appconfig %s" str 
         | Appservice str -> sprintf "Appservice %s" str 
         | Arcappliance str -> sprintf "Arcappliance %s" str 
         | Aro str -> sprintf "Aro %s" str 
         | Artifacts str -> sprintf "Artifacts %s" str 
         | Attestation str -> sprintf "Attestation %s" str 
         | Automation str -> sprintf "Automation %s" str 
         | Backup str -> sprintf "Backup %s" str 
         | Baremetalinstance str -> sprintf "Baremetalinstance %s" str 
         | Batch str -> sprintf "Batch %s" str 
         | Batchai str -> sprintf "Batchai %s" str 
         | Bicep str -> sprintf "Bicep %s" str 
         | Billing str -> sprintf "Billing %s" str 
         | Blockchain str -> sprintf "Blockchain %s" str 
         | Blueprint str -> sprintf "Blueprint %s" str 
         | Boards str -> sprintf "Boards %s" str 
         | Bot str -> sprintf "Bot %s" str 
         | Cache str -> sprintf "Cache %s" str 
         | Cdn str -> sprintf "Cdn %s" str 
         | CliTranslator str -> sprintf "CliTranslator %s" str 
         | Cloud str -> sprintf "Cloud %s" str 
         | CloudService str -> sprintf "CloudService %s" str 
         | Codespace str -> sprintf "Codespace %s" str 
         | Cognitiveservices str -> sprintf "Cognitiveservices %s" str 
         | Communication str -> sprintf "Communication %s" str 
         | Config str -> sprintf "Config %s" str 
         | Configure str -> sprintf "Configure %s" str 
         | Confluent str -> sprintf "Confluent %s" str 
         | Connectedk8s str -> sprintf "Connectedk8s %s" str 
         | Connectedmachine str -> sprintf "Connectedmachine %s" str 
         | Consumption str -> sprintf "Consumption %s" str 
         | Container str -> sprintf "Container %s" str 
         | Cosmosdb str -> sprintf "Cosmosdb %s" str 
         | Costmanagement str -> sprintf "Costmanagement %s" str 
         | Csvmware str -> sprintf "Csvmware %s" str 
         | Customlocation str -> sprintf "Customlocation %s" str 
         | CustomProviders str -> sprintf "CustomProviders %s" str 
         | Databox str -> sprintf "Databox %s" str 
         | Databoxedge str -> sprintf "Databoxedge %s" str 
         | Databricks str -> sprintf "Databricks %s" str 
         | Datafactory str -> sprintf "Datafactory %s" str 
         | Datashare str -> sprintf "Datashare %s" str 
         | DedicatedHsm str -> sprintf "DedicatedHsm %s" str 
         | Demo str -> sprintf "Demo %s" str 
         | Deployment str -> sprintf "Deployment %s" str 
         | Deploymentmanager str -> sprintf "Deploymentmanager %s" str 
         | DeploymentScripts str -> sprintf "DeploymentScripts %s" str 
         | Desktopvirtualization str -> sprintf "Desktopvirtualization %s" str 
         | Devops str -> sprintf "Devops %s" str 
         | Disk str -> sprintf "Disk %s" str 
         | DiskAccess str -> sprintf "DiskAccess %s" str 
         | DiskEncryptionSet str -> sprintf "DiskEncryptionSet %s" str 
         | Dla str -> sprintf "Dla %s" str 
         | Dls str -> sprintf "Dls %s" str 
         | Dms str -> sprintf "Dms %s" str 
         | Dt str -> sprintf "Dt %s" str 
         | Eventgrid str -> sprintf "Eventgrid %s" str 
         | Eventhubs str -> sprintf "Eventhubs %s" str 
         | Extension str -> sprintf "Extension %s" str 
         | Feature str -> sprintf "Feature %s" str 
         | Feedback str -> sprintf "Feedback %s" str 
         | Find str -> sprintf "Find %s" str 
         | Footprint str -> sprintf "Footprint %s" str 
         | Functionapp str -> sprintf "Functionapp %s" str 
         | Fzf str -> sprintf "Fzf %s" str 
         | Graph str -> sprintf "Graph %s" str 
         | Group str -> sprintf "Group %s" str 
         | Guestconfig str -> sprintf "Guestconfig %s" str 
         | Hack str -> sprintf "Hack %s" str 
         | Hanainstance str -> sprintf "Hanainstance %s" str 
         | Hdinsight str -> sprintf "Hdinsight %s" str 
         | Healthbot str -> sprintf "Healthbot %s" str 
         | Healthcareapis str -> sprintf "Healthcareapis %s" str 
         | HpcCache str -> sprintf "HpcCache %s" str 
         | Identity str -> sprintf "Identity %s" str 
         | Image str -> sprintf "Image %s" str 
         | ImportExport str -> sprintf "ImportExport %s" str 
         | Interactive str -> sprintf "Interactive %s" str 
         | InternetAnalyzer str -> sprintf "InternetAnalyzer %s" str 
         | Iot str -> sprintf "Iot %s" str 
         | K8sconfiguration str -> sprintf "K8sconfiguration %s" str 
         | K8sConfiguration str -> sprintf "K8sConfiguration %s" str 
         | K8sExtension str -> sprintf "K8sExtension %s" str 
         | Keyvault str -> sprintf "Keyvault %s" str 
         | Kusto str -> sprintf "Kusto %s" str 
         | Lab str -> sprintf "Lab %s" str 
         | LocalContext str -> sprintf "LocalContext %s" str 
         | Lock str -> sprintf "Lock %s" str 
         | Logic str -> sprintf "Logic %s" str 
         | Login str -> sprintf "Login %s" str 
         | Logout str -> sprintf "Logout %s" str 
         | Maintenance str -> sprintf "Maintenance %s" str 
         | Managedapp str -> sprintf "Managedapp %s" str 
         | ManagedCassandra str -> sprintf "ManagedCassandra %s" str 
         | Managedservices str -> sprintf "Managedservices %s" str 
         | Managementpartner str -> sprintf "Managementpartner %s" str 
         | Maps str -> sprintf "Maps %s" str 
         | Mariadb str -> sprintf "Mariadb %s" str 
         | Mesh str -> sprintf "Mesh %s" str 
         | Ml str -> sprintf "Ml %s" str 
         | Monitor str -> sprintf "Monitor %s" str 
         | Mysql str -> sprintf "Mysql %s" str 
         | Netappfiles str -> sprintf "Netappfiles %s" str 
         | Network str -> sprintf "Network %s" str 
         | Next str -> sprintf "Next %s" str 
         | NotificationHub str -> sprintf "NotificationHub %s" str 
         | Offazure str -> sprintf "Offazure %s" str 
         | Openshift str -> sprintf "Openshift %s" str 
         | Peering str -> sprintf "Peering %s" str 
         | Pipelines str -> sprintf "Pipelines %s" str 
         | Policy str -> sprintf "Policy %s" str 
         | Portal str -> sprintf "Portal %s" str 
         | Postgres str -> sprintf "Postgres %s" str 
         | Powerbi str -> sprintf "Powerbi %s" str 
         | Ppg str -> sprintf "Ppg %s" str 
         | Provider str -> sprintf "Provider %s" str 
         | Providerhub str -> sprintf "Providerhub %s" str 
         | Quantum str -> sprintf "Quantum %s" str 
         | Redis str -> sprintf "Redis %s" str 
         | Redisenterprise str -> sprintf "Redisenterprise %s" str 
         | Relay str -> sprintf "Relay %s" str 
         | RemoteRenderingAccount str -> sprintf "RemoteRenderingAccount %s" str 
         | Repos str -> sprintf "Repos %s" str 
         | Reservations str -> sprintf "Reservations %s" str 
         | Resource str -> sprintf "Resource %s" str 
         | ResourceMover str -> sprintf "ResourceMover %s" str 
         | Rest str -> sprintf "Rest %s" str 
         | Role str -> sprintf "Role %s" str 
         | Sapmonitor str -> sprintf "Sapmonitor %s" str 
         | Search str -> sprintf "Search %s" str 
         | Security str -> sprintf "Security %s" str 
         | SelfTest str -> sprintf "SelfTest %s" str 
         | Sentinel str -> sprintf "Sentinel %s" str 
         | Servicebus str -> sprintf "Servicebus %s" str 
         | Sf str -> sprintf "Sf %s" str 
         | Sig str -> sprintf "Sig %s" str 
         | Signalr str -> sprintf "Signalr %s" str 
         | Snapshot str -> sprintf "Snapshot %s" str 
         | SpatialAnchorsAccount str -> sprintf "SpatialAnchorsAccount %s" str 
         | SpringCloud str -> sprintf "SpringCloud %s" str 
         | Sql str -> sprintf "Sql %s" str 
         | Ssh str -> sprintf "Ssh %s" str 
         | Sshkey str -> sprintf "Sshkey %s" str 
         | StackHci str -> sprintf "StackHci %s" str 
         | Staticwebapp str -> sprintf "Staticwebapp %s" str 
         | Storage str -> sprintf "Storage %s" str 
         | Storagesync str -> sprintf "Storagesync %s" str 
         | StreamAnalytics str -> sprintf "StreamAnalytics %s" str 
         | Support str -> sprintf "Support %s" str 
         | Synapse str -> sprintf "Synapse %s" str 
         | Tag str -> sprintf "Tag %s" str 
         | Ts str -> sprintf "Ts %s" str 
         | Tsi str -> sprintf "Tsi %s" str 
         | Upgrade str -> sprintf "Upgrade %s" str 
         | Version str -> sprintf "Version %s" str 
         | Vm str -> sprintf "Vm %s" str 
         | Vmss str -> sprintf "Vmss %s" str 
         | Vmware str -> sprintf "Vmware %s" str 
         | Webapp str -> sprintf "Webapp %s" str       
        
module AzCli =        

    let runPowerOrShRaw commands =
         let shell, args =
             if Environment.isWindows then
                 "powershell", sprintf " az %s " commands
             else
                 "az", commands
         printfn "%s" args
         args
         |> Args.fromWindowsCommandLine 
         |> Seq.toList
         |> CreateProcess.fromRawCommand shell
         |> CreateProcess.redirectOutput
         |> CreateProcess.withTimeout TimeSpan.MaxValue
         |> Proc.run

    /// Runs the given process and returns the process result.
    let  run  command =
         let args = command |> parse
         
         let result = runPowerOrShRaw args    

         result.ExitCode
    
