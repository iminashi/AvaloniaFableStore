namespace AvaloniaFableStore

open Fable

type State =
    { Count: int
      Lag: int }

    static member Initial =
        { Count = 0
          Lag = 0 }

module State =
    let store = new Store<State>(State.Initial)

    let private doChange change state =
        if state.Lag <> 0 then
            async {
                do! Async.Sleep state.Lag
                store.Update(fun state -> { state with Count = state.Count + change }) }
            |> Async.Start
            state
        else
            { state with Count = state.Count + change }

    let increment () = store.Update(doChange +1)

    let decrement () = store.Update(doChange -1)

    let setLag lag =
        store.Update(fun state -> { state with Lag = max 0 lag })
