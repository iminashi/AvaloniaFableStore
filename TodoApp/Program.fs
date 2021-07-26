namespace TodoApp

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Markup.Xaml.Styling
open Avalonia.Themes.Fluent
open System

type App() =
    inherit Application()
    let name = "Todo App"

    override this.Initialize() =
        this.Styles.Add <| FluentTheme(baseUri = null, Mode = FluentThemeMode.Dark)
        this.Styles.Add <| StyleInclude(baseUri = null, Source = Uri("avares://TodoApp/Styles.axaml"))
        this.Name <- name

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- MainWindow.window name
            base.OnFrameworkInitializationCompleted()
        | _ ->
            ()

module Program =
    [<EntryPoint>]
    let main (args: string[]) =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .StartWithClassicDesktopLifetime(args)
