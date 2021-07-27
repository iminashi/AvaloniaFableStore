module ItemTemplates

open Avalonia
open Avalonia.Controls
open FSharp.Control.Reactive
open SharedLibrary
open Models

let todoItem =
    DataTemplate.create <| fun todoItem ->
        CheckBox(Margin = Thickness(4.),
                 IsChecked = todoItem.IsChecked,
                 Content = todoItem.Description)
        |> apply (fun checkBox ->
            checkBox.GetObservable(CheckBox.IsCheckedProperty)
            |> Observable.skip 1
            |> Observable.subscribe (fun isChecked ->
                State.changeChecked todoItem.Id (isChecked.GetValueOrDefault()))
            |> ignore)
