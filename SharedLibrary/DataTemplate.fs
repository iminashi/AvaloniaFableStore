module SharedLibrary.DataTemplate

open Avalonia.Controls
open Avalonia.Controls.Templates

let create<'a, 'b when 'b :> IControl> (f: 'a -> 'b) =
    { new IDataTemplate with
    
        member _.Build(param: obj): IControl = 
            match param with
            | :? 'a as data ->
                f data :> IControl
            | _ ->
                null
    
        member _.Match(data: obj): bool = 
            data :? 'a }
