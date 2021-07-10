module AvaloniaFableStore.Counter

open Avalonia.Layout

let view () =
    vStack' centered
        [
            text (fun x ->
                x.HorizontalAlignment <- HorizontalAlignment.Center
                x.FontSize <- 24.
                State.subscribe (fun state -> x.Text <- $"Count: %i{state.Count}") |> ignore)
                    
            hStack [
                button "-" State.decrement
                button "+" State.increment
            ]
        ]
