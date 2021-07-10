[<AutoOpen>]
module Controls

open Avalonia.Controls
open Avalonia.Layout

[<AutoOpen>]
module Utils =
    let inline apply f x = f x; x

    let centered (x: Layoutable) =
        x.HorizontalAlignment <- HorizontalAlignment.Center
        x.VerticalAlignment <- VerticalAlignment.Center

let button content onClick =
    RepeatButton(Content = content,
                 HorizontalContentAlignment = HorizontalAlignment.Center,
                 VerticalContentAlignment = VerticalAlignment.Center,
                 MinHeight = 50.,
                 MinWidth = 70.)
    |> apply (fun b -> b.Click.Add (ignore >> onClick))

let private stackPanel orientation children =
    StackPanel(Orientation = orientation)
    |> apply (fun s -> s.Children.AddRange children)

let hStack children = stackPanel Orientation.Horizontal children

let vStack children = stackPanel Orientation.Vertical children

let vStack' setProps children =
    stackPanel Orientation.Vertical children
    |> apply setProps

let text setProps =
    TextBlock()
    |> apply setProps

let window title content =
    Window(Title = title, Width = 300., Height = 100., Content = content)
