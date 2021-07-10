module AvaloniaFableStore.Counter

open Avalonia
open Avalonia.Controls
open FSharp.Control.Reactive
open LayoutUtils

let private countText =
    text <| fun text ->
        centerH text
        text.FontSize <- 24.

        (Localization.observable, State.store)
        ||> Observable.combineLatest
        |> Observable.map (fun (loc, state) -> sprintf "%s: %i" loc.Count state.Count)
        |> bind text TextBlock.TextProperty

let private changeLanguageButton =
    button Localization.changeLanguage <| fun btn ->
        topRight btn
        btn.Width <- 50.
        btn.Padding <- Thickness(4.)
        btn.Margin <- Thickness(2.)
        btn.FontSize <- 11.

        Localization.map (fun s -> box s.LanguageCode)
        |> bind btn Button.ContentProperty

let view () =
    panel [
        vStack' center [
            countText
       
            hStack [
                repeatButton "-" State.decrement
                repeatButton "+" State.increment
            ]
        ]

        changeLanguageButton
    ]
