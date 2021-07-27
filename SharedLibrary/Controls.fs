module SharedLibrary.Controls

open Avalonia.Controls
open Avalonia.Layout

let private stackPanel orientation children =
    StackPanel(Orientation = orientation)
    |> apply (fun s -> s.Children.AddRange children)

let hStack children = stackPanel Orientation.Horizontal children

let hStack' setProps children =
    hStack children
    |> apply setProps

let vStack children = stackPanel Orientation.Vertical children

let vStack' setProps children =
    vStack children
    |> apply setProps

let text setProps =
    TextBlock()
    |> apply setProps

let panel children =
    Panel()
    |> apply (fun p -> p.Children.AddRange children)

let numericUpDown setProps =
    NumericUpDown()
    |> apply setProps

let dockPanel children =
    DockPanel()
    |> apply (fun dock -> dock.Children.AddRange children)

let button content onClick =
    Button(Content = content)
    |> apply (fun b -> b.Click.Add (ignore >> onClick))
