module State

open Fable
open System.Diagnostics
open FSharp.Control.Reactive

type State =
    { Page: Page
      Items: TodoItem list }

    static member Init =
        { Page = Page.ItemList
          Items = Database.getItems() }

let update, store =
    let s = new Store<State>(State.Init)
    s.Update, s |> Observable.asObservable

let changeChecked id isChecked state =
    let items =
        state.Items
        |> List.map (fun todo ->
            if todo.Id = id then
                { todo with IsChecked = isChecked }
            else
                todo)
    { state with Items = items }

let changePage page state =
    { state with Page = page }

let addItem description state =
    { state with Items = TodoItem.Create(description)::state.Items
                 Page = Page.ItemList }

#if DEBUG
store.Subscribe (fun state -> Debug.WriteLine state)
|> ignore
#endif
