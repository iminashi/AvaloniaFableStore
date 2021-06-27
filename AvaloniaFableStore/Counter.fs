module Counter

open Fable
open Avalonia.Layout

let view title =
    let store = new Store<int>(0)
    let update = store.Update

    window
        title
        (vStack'
            (fun x -> x.HorizontalAlignment <- HorizontalAlignment.Center
                      x.VerticalAlignment <- VerticalAlignment.Center)
            [
                text store

                hStack [
                    button "+" (fun () -> update (fun x -> x + 1))
                    button "-" (fun () -> update (fun x -> x - 1))
                ]
            ]
        )
