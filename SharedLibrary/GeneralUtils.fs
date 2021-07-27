[<AutoOpen>]
module SharedLibrary.GeneralUtils

open Avalonia
open System

let inline apply f x = f x; x

let inline bind (obj: IAvaloniaObject) (prop: AvaloniaProperty<'a>) (source: IObservable<'a>) =
    obj.Bind(prop, source)
    |> ignore
