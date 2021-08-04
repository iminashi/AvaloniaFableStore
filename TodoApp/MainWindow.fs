module MainWindow

open Avalonia.Controls
open FSharp.Control.Reactive
open SharedLibrary

let window title =
    Window(Title = title, Width = 200., Height = 400.)
    |> apply (fun window ->
        State.mapDistinct (fun x -> x.Page)
        |> Observable.map (function
            | Page.AddItem -> AddItemView.view |> box
            | Page.ItemList -> TodoListView.view |> box)
        |> bind window Window.ContentProperty)
