[<AutoOpen>]
module Controls

open Avalonia
open Avalonia.Controls
open Avalonia.Layout
open System

[<AutoOpen>]
module Utils =
    let inline apply f x = f x; x

    let inline bind (obj: IAvaloniaObject) (prop: AvaloniaProperty<'a>) (source: IObservable<'a>) =
        obj.Bind(prop, source) |> ignore

let repeatButton content onClick =
    RepeatButton(Content = content,
                 HorizontalContentAlignment = HorizontalAlignment.Center,
                 VerticalContentAlignment = VerticalAlignment.Center,
                 MinHeight = 50.,
                 MinWidth = 70.)
    |> apply (fun b -> b.Click.Add (ignore >> onClick))

let button onClick setProps =
    Button(HorizontalContentAlignment = HorizontalAlignment.Center,
           VerticalContentAlignment = VerticalAlignment.Center)
    |> apply (fun b ->
        setProps b
        b.Click.Add (ignore >> onClick))

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

let window title content =
    Window(Title = title, Width = 300., Height = 140., Content = content)
