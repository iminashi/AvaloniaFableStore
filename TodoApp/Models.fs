module Models

open System

type Page = ItemList | AddItem

type TodoItem =
    { Id: Guid
      Description: string
      IsChecked: bool }

    static member Create(desc, ?isChecked) =
        { Id = Guid.NewGuid()
          Description = desc 
          IsChecked = defaultArg isChecked false }
