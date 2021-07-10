namespace AvaloniaFableStore

open Fable

type State =
    { Count: int }

    static member Initial =
        { Count = 0 }

module State =
    let store = new Store<State>(State.Initial)

    let subscribe (f: State -> unit) = store.Subscribe f

    let increment () = store.Update(fun state -> { state with Count = state.Count + 1 })
    let decrement () = store.Update(fun state -> { state with Count = state.Count - 1 })
