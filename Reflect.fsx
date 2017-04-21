open System
open System.Reflection

type Qualifier =
    | Public of Qualifier
    | Static of Qualifier
    | Members of Type
    | Methods of Type

let PublicStaticFlags = BindingFlags.Public ||| BindingFlags.Static

let showMethodNames<'a> flags =
    typeof<'a>.GetMethods(flags)
    |> Seq.groupBy (fun mi -> mi.Name)
    |> Seq.map (fun (g, v) -> (g, v |> Seq.length))
    |> Seq.map (fun (g, n) -> match n with
                              | _ when n > 1 -> sprintf "%s (%d overloads)" g n
                              | _ -> sprintf "%s" g)
    |> Seq.sort
    |> Seq.iter (printfn "%s")
