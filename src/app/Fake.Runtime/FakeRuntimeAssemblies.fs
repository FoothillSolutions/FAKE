module Fake.Runtime.FakeRuntime

#if DOTNETCORE

let internal getRuntimeAssemblies(nuGetPackage, version, pathSuffix) = 
      // We need use "real" reference assemblies as using the currently running runtime assemlies doesn't work:
      // see https://github.com/fsharp/FAKE/pull/1695

      // Therefore we download the reference assemblies (the NETStandard.Library package)
      // and add them in addition to what we have resolved, 
      // we use the sources in the paket.dependencies to give the user a chance to overwrite.

      // Note: This package/version needs to updated together with our "framework" variable below and needs to 
      // be compatible with the runtime we are currently running on.
      let rootDir = Directory.GetCurrentDirectory()
      let packageName = Domain.PackageName("Microsoft.NETCore.App.Ref")
      let version = SemVer.Parse("6.0.0-preview.6.21352.12")
      let existingpkg = NuGetCache.GetTargetUserNupkg packageName version
      let extractedFolder =
        if File.Exists existingpkg then
          // Shortcut in order to prevent requests to nuget sources if we have it downloaded already
          Path.GetDirectoryName existingpkg
        else
          let sources = paketDependenciesFile.Value.Groups.[groupName].Sources
          let versions =
            Paket.NuGet.GetVersions false None rootDir (PackageResolver.GetPackageVersionsParameters.ofParams sources groupName packageName)
            |> Async.RunSynchronously
            |> dict
          let source =
            match versions.TryGetValue(version) with
            | true, v when v.Length > 0 -> v |> Seq.head
            | _ -> failwithf "Could not find package '%A' with version '%A' in any package source of group '%A', but fake needs this package to compile the script" packageName version groupName    
          
          let _, extractedFolder =
            Paket.NuGet.DownloadAndExtractPackage
              (None, rootDir, false, PackagesFolderGroupConfig.NoPackagesFolder,
               source, [], Paket.Constants.MainDependencyGroup,
               packageName, version, PackageResolver.ResolvedPackageKind.Package, false, false, false, false)
            |> Async.RunSynchronously
          extractedFolder
      printfn "%s" extractedFolder
      let sdkDir = Path.Combine(extractedFolder, pathSuffix)
      Directory.GetFiles(sdkDir, "*.dll")
      |> Seq.toList

let internal tryGetSDKVersionFromGlobalJson = DotNet.tryGetSDKVersionFromGlobalJson()
let sdkVersionIsDotNet6 = tryGetSDKVersionFromGlobalJson.IsSome && tryGetSDKVersionFromGlobalJson.Value.StartsWith "6"

let referencedAssembliesVersion = 
  // here we will match for .NET 6 sdk from a global.json file. If found we will use
  // .NET 6 runtime assemblies. Otherwise we will default to .Netstandard 2.0.3
  match tryGetSDKVersionFromGlobalJson.IsSome && tryGetSDKVersionFromGlobalJson.Value.StartsWith "6" with
  | true ->
    Trace.traceVerbose <| (sprintf "%s" "Using .Net 6 assemblies")
    Trace.traceVerbose <| (sprintf"Runtime path: %s" net6ReferenceAssemblies)
    Runners.ReferencedAssembliesVersion.DotNet
  |  false -> 
    Trace.traceVerbose <| (sprintf"%s" "Use .Netstandard assemblies") 
    Runners.ReferencedAssembliesVersion.NetStandard


let getCurrentSDKReferenceFiles() =
  // here we will match for .NET 6 sdk from a global.json file. If found we will use
  // .NET 6 runtime assemblies. Otherwise we will default to .Netstandard 2.0.3 
  match sdkVersionIsDotNet6 with
  | true ->
    getRuntimeAssemblies("Microsoft.NETCore.App.Ref", "6.0.0-preview.6.21352.12", Path.Combine("ref", "net6.0"))
    |> Seq.toList
  | false ->
    getRuntimeAssemblies("NETStandard.Library", "2.0.0", Path.Combine("build", "netstandard2.0", "ref"))

#endif
