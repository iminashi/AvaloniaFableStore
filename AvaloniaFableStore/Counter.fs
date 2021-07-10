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
        margin 2. btn
        btn.Width <- 50.
        btn.Padding <- Thickness(4.)
        btn.FontSize <- 11.

        Localization.map (fun s -> box s.LanguageCode)
        |> bind btn Button.ContentProperty

let private lagControl =
    hStack' centerH [
        text <| fun text ->
            centerV text
            text.Margin <- Thickness(2., 0.)

            Localization.map (fun s -> s.Lag)
            |> bind text TextBlock.TextProperty

        numericUpDown <| fun nud ->
            nud.Minimum <- 0.
            nud.Maximum <- 5000.

            nud.GetObservable(NumericUpDown.ValueProperty).Add (int >> State.setLag)
    ]
    
let view () =
    panel [
        vStack' centerV [
            countText
       
            hStack' centerH [
                repeatButton "-" State.decrement
                repeatButton "+" State.increment
            ]

            lagControl |> apply (margin 4.)
        ]

        changeLanguageButton
    ]
