module AddItemView

open Avalonia
open Avalonia.Controls
open System
open Controls
open Models

let view =
    let textBox = TextBox(AcceptsReturn = true, Watermark = "Enter your TODO")

    let cancelButton = 
        button "Cancel" <| fun () ->
            State.changePage ItemList
            textBox.Text <- String.Empty

    let okButton =
        button "OK" <| fun () ->
            State.addItem textBox.Text
            textBox.Text <- String.Empty

    textBox.GetObservable(TextBox.TextProperty)
    |> Observable.map (String.IsNullOrWhiteSpace >> not)
    |> bind okButton Button.IsEnabledProperty

    cancelButton.SetValue(DockPanel.DockProperty, Dock.Bottom) |> ignore
    okButton.SetValue(DockPanel.DockProperty, Dock.Bottom) |> ignore

    dockPanel [
        cancelButton
        okButton
        textBox
    ]
