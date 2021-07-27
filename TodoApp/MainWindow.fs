module MainWindow

open Avalonia.Controls
open FSharp.Control.Reactive
open SharedLibrary
open Models

let window title =
    Window(Title = title, Width = 200., Height = 400.)
    |> apply (fun window ->
        State.store
        |> Observable.map (fun x -> x.Page)
        |> Observable.distinctUntilChanged
        |> Observable.map (function
            | AddItem -> AddItemView.view |> box
            | ItemList -> TodoListView.view |> box)
        |> bind window Window.ContentProperty)
