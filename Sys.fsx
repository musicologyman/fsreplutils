open System
open System.IO

type Action = 
    | Pwd
    | Ls 
    | Cd of string
    | MkDir of string

let changeDirectory path =
    if path |> Directory.Exists then
        Environment.CurrentDirectory <- path
    else
        failwithf "The path %s does not exist." path

let makeDir path =
    ()
    
    
    

let sys action =
    match action with
    | Pwd -> printfn "\n%s\n" Environment.CurrentDirectory
    | Ls -> Directory.GetFiles(".") |> Array.iter (printfn "%s")
    | Cd s -> changeDirectory s
    | MkDir s -> makeDir path 
