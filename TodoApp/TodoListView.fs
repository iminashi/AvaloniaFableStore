module TodoListView

open Avalonia.Controls
open System.Collections
open SharedLibrary
open SharedLibrary.Controls
open SharedLibrary.LayoutUtils

let view =
    let addItembutton =
        button "Add an item" (fun () ->
            State.update <| State.changePage Page.AddItem)

    let itemsControl = ItemsControl(ItemTemplate = ItemTemplates.todoItem)
    State.map (fun x -> x.Items :> IEnumerable)
    |> bind itemsControl ItemsControl.ItemsProperty

    dockPanel [
        addItembutton |> dockBottom
        itemsControl
    ]
