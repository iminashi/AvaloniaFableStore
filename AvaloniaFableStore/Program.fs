namespace AvaloniaFableStore

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Themes.Fluent

type App() =
    inherit Application()
    let name = "Fable Store Counter"

    override this.Initialize() =
        this.Styles.Add <| FluentTheme(baseUri = null, Mode = FluentThemeMode.Dark)
        this.Name <- name

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- Controls.window name (Counter.view())
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
