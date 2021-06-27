[<AutoOpen>]
module Controls

open Avalonia.Controls
open Avalonia.Layout
open Fable

[<AutoOpen>]
module Utils =
    let with' f x = f x; x

let button content onClick =
    RepeatButton(Content = content,
                 HorizontalContentAlignment = HorizontalAlignment.Center,
                 VerticalContentAlignment = VerticalAlignment.Center,
                 MinHeight = 50.,
                 MinWidth = 70.)
    |> with' (fun b -> b.Click.Add (ignore >> onClick))

let private stackPanel orientation children =
    StackPanel(Orientation = orientation)
    |> with' (fun s -> s.Children.AddRange children)

let hStack children = stackPanel Orientation.Horizontal children

let vStack children = stackPanel Orientation.Vertical children

let vStack' f children =
    stackPanel Orientation.Vertical children
    |> with' f

let text (store: Store<int>) =
    TextBlock(HorizontalAlignment = HorizontalAlignment.Center, FontSize = 24.)
    |> with' (fun t -> store.Subscribe (fun value -> t.Text <- $"Value: %i{value}") |> ignore)

let window title content =
    Window(Title = title, Width = 300., Height = 100.)
    |> with' (fun w -> w.Content <- content)
