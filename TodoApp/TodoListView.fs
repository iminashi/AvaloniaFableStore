module TodoListView

open Avalonia.Controls
open System.Collections
open SharedLibrary
open SharedLibrary.Controls
open SharedLibrary.LayoutUtils
open Models

let view =
    let addItembutton =
        button "Add an item" (fun () -> State.changePage AddItem)

    let itemsControl = ItemsControl(ItemTemplate = ItemTemplates.todoItem)
    State.store
    |> Observable.map (fun x -> x.Items :> IEnumerable)
    |> bind itemsControl ItemsControl.ItemsProperty

    dockPanel [
        addItembutton |> dockBottom
        itemsControl
    ]
