module Localization

open Fable
open FSharp.Control.Reactive

[<RequireQualifiedAccess>]
type private Language = English | Finnish

type Strings =
    { Count: string
      LanguageCode: string
      Lag: string }

let English =
    { Count = "Count"
      LanguageCode = "EN"
      Lag = "Lag" }

let Finnish =
    { Count = "Arvo"
      LanguageCode = "FI"
      Lag = "Viive" }

let private current = new Store<Language>(Language.English)
let private store = new Store<Strings>(English)
let observable = Observable.asObservable store

current.Add(fun current ->
    store.Update (fun _ -> 
        match current with
        | Language.English -> English
        | Language.Finnish -> Finnish)
)

let map f = Observable.map f store

let changeLanguage () =
    current.Update (function
        | Language.English -> Language.Finnish
        | Language.Finnish -> Language.English)
