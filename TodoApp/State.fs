module State

open Fable
open Models
open System.Diagnostics

type State =
    { Page: Page
      Items: TodoItem list }

let store = new Store<State>({ Page = ItemList; Items = Database.getItems() })

let changeChecked id isChecked =
    store.Update (fun state ->
        let items =
            state.Items
            |> List.map (fun y ->
                if y.Id = id then
                    { y with IsChecked = isChecked }
                else
                    y)
        { state with Items = items })

let changePage page =
    store.Update (fun state -> { state with Page = page })

let addItem description =
    store.Update (fun state ->
        { state with Items = TodoItem.Create(description)::state.Items
                     Page = ItemList })

#if DEBUG
store.Subscribe (fun state -> Debug.WriteLine state)
|> ignore
#endif
