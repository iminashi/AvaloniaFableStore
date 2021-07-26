module Database

open Models

let getItems () =
    [ TodoItem.Create("Walk the dog")
      TodoItem.Create("Buy some milk")
      TodoItem.Create("Learn Avalonia", isChecked=true) ]
