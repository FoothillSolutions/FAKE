#r "paket:
nuget SchlenkR.FsHttp
nuget Fake.DotNet.Cli
nuget Fake.Core.Trace
nuget Fake.Core.Target //"

open Fake.Core
open Fake.DotNet
open FsHttp
open FsHttp.DslCE

Trace.setVerbose()

FsHttp.Fsi.Init.init ()

//*** Define Targets ***
Target.create "Clean" (fun _ -> Trace.log " --- Cleaning stuff --- ")

Target.create "Build" (fun _ -> Trace.log " --- Building the app --- ")

Target.create "Deploy" (fun _ -> 
    Trace.log " --- Deploying app --- "
    
    http {
        GET "https://reqres.in/api/users"
        CacheControl "no-cache"
        exp
    }
    |> Response.toText
    |> printfn "%s"

    printfn ""
    printfn ""
    printfn ""
    printfn "I'm in .NET 6 :))))))))))"    
    printfn ""
    printfn ""
    printfn ""
)

open Fake.Core.TargetOperators

// Async.Sleep(5000) |> Async.RunSynchronously
// *** Define Dependencies ***
"Clean" ==> "Build" ==> "Deploy"

// *** Start Build ***
Target.runOrDefault "Deploy"
