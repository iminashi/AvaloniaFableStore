module AddItemView

open Avalonia
open Avalonia.Controls
open System
open SharedLibrary
open SharedLibrary.Controls
open SharedLibrary.LayoutUtils

let view =
    let textBox = TextBox(AcceptsReturn = true, Watermark = "Enter your TODO")

    let cancelButton = 
        button "Cancel" <| fun () ->
            State.update (State.changePage Page.ItemList)
            textBox.Text <- String.Empty

    let okButton =
        button "OK" <| fun () ->
            State.update (State.addItem textBox.Text)
            textBox.Text <- String.Empty

    textBox.GetObservable(TextBox.TextProperty)
    |> Observable.map (String.IsNullOrWhiteSpace >> not)
    |> bind okButton Button.IsEnabledProperty

    dockPanel [
        cancelButton |> dockBottom
        okButton |> dockBottom
        textBox
    ]
