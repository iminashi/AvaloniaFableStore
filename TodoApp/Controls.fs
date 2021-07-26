module Controls

open Avalonia
open Avalonia.Controls
open System

[<AutoOpen>]
module Utils =
    let inline apply f x = f x; x

    let inline bind (obj: IAvaloniaObject) (prop: AvaloniaProperty<'a>) (source: IObservable<'a>) =
        obj.Bind(prop, source) |> ignore

let dockPanel children =
    DockPanel()
    |> apply (fun dock -> dock.Children.AddRange children)

let button content onClick =
    Button(Content = content)
    |> apply (fun b -> b.Click.Add (ignore >> onClick))
