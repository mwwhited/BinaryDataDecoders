namespace BinaryDataDecoders.FSharp.Samples

module Say =
    let hello name =
        printfn "Hello %s" name

module test = 
    let phillip' = {| name="Phillip"; age=28 |}
