module ItemTemplate

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Templates
open FSharp.Control.Reactive
open Controls
open Models

let create<'a, 'b when 'b :> IControl> (f: 'a -> 'b) =
    { new IDataTemplate with
    
        member _.Build(param: obj): IControl = 
            match param with
            | :? 'a as data ->
                f data :> IControl
            | _ ->
                null
    
        member _.Match(data: obj): bool = 
            data :? 'a }

let todoItem =
    create <| fun todoItem ->
        CheckBox(Margin = Thickness(4.),
                 IsChecked = todoItem.IsChecked,
                 Content = todoItem.Description)
        |> apply (fun checkBox ->
            checkBox.GetObservable(CheckBox.IsCheckedProperty)
            |> Observable.skip 1
            |> Observable.subscribe (fun isChecked ->
                State.changeChecked todoItem.Id (isChecked.GetValueOrDefault()))
            |> ignore)
