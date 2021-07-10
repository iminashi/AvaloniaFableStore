module LayoutUtils

open Avalonia.Layout

let inline center (x: Layoutable) =
    x.HorizontalAlignment <- HorizontalAlignment.Center
    x.VerticalAlignment <- VerticalAlignment.Center

let inline centerH (x: Layoutable) =
    x.HorizontalAlignment <- HorizontalAlignment.Center

let inline topRight (x: Layoutable) =
    x.HorizontalAlignment <- HorizontalAlignment.Right
    x.VerticalAlignment <- VerticalAlignment.Top
