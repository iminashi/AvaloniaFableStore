[<AutoOpen>]
module CustomControls

open Avalonia.Controls
open Avalonia.Layout
open SharedLibrary

let repeatButton content onClick =
    RepeatButton(Content = content,
                 HorizontalContentAlignment = HorizontalAlignment.Center,
                 VerticalContentAlignment = VerticalAlignment.Center,
                 MinHeight = 50.,
                 MinWidth = 70.)
    |> apply (fun b -> b.Click.Add (ignore >> onClick))

let button' onClick setProps =
    Button(HorizontalContentAlignment = HorizontalAlignment.Center,
           VerticalContentAlignment = VerticalAlignment.Center)
    |> apply (fun b ->
        setProps b
        b.Click.Add (ignore >> onClick))

let window title content =
    Window(Title = title, Width = 300., Height = 140., Content = content)
