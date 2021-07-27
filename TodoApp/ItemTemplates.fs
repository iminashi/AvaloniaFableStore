module ItemTemplates

open Avalonia
open Avalonia.Controls
open FSharp.Control.Reactive
open SharedLibrary

let todoItem =
    DataTemplate.create <| fun todoItem ->
        CheckBox(Margin = Thickness(4.),
                 IsChecked = todoItem.IsChecked,
                 Content = todoItem.Description)
        |> apply (fun checkBox ->
            checkBox.GetObservable(CheckBox.IsCheckedProperty)
            |> Observable.skip 1
            |> Observable.subscribe (fun isChecked ->
                let isChecked = isChecked.GetValueOrDefault()
                State.update <| State.changeChecked todoItem.Id isChecked)
            |> ignore)
