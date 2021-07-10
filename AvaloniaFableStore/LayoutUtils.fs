module LayoutUtils

open Avalonia
open Avalonia.Layout

let inline center (x: Layoutable) =
    x.HorizontalAlignment <- HorizontalAlignment.Center
    x.VerticalAlignment <- VerticalAlignment.Center

let inline centerH (x: Layoutable) =
    x.HorizontalAlignment <- HorizontalAlignment.Center

let inline centerV (x: Layoutable) =
    x.VerticalAlignment <- VerticalAlignment.Center

let inline topRight (x: Layoutable) =
    x.HorizontalAlignment <- HorizontalAlignment.Right
    x.VerticalAlignment <- VerticalAlignment.Top

let inline margin m (x: Layoutable) =
    x.Margin <- Thickness(m)
