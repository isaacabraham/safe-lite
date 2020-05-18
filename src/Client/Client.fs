module Client

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Shared
open Thoth.Fetch

type Model =
    { Counter: Counter option }

type Msg =
    | Increment
    | Decrement
    | InitialCountLoaded of Counter

let initialCounter() = Fetch.fetchAs<_, Counter> "/api/init"

let init() =
    let initialModel = { Counter = None }
    let loadCountCmd = Cmd.OfPromise.perform initialCounter () InitialCountLoaded
    initialModel, loadCountCmd

let update msg model =
    match model.Counter, msg with
    | Some counter, Increment ->
        let nextModel = { model with Counter = Some { Value = counter.Value + 1 } }
        nextModel, Cmd.none
    | Some counter, Decrement ->
        let nextModel = { model with Counter = Some { Value = counter.Value - 1 } }
        nextModel, Cmd.none
    | _, InitialCountLoaded initialCount ->
        let nextModel = { Counter = Some initialCount }
        nextModel, Cmd.none
    | _ ->
        model, Cmd.none

let show =
    function
    | { Counter = Some counter } -> string counter.Value
    | { Counter = None } -> "Loading..."

let view model dispatch =
    div [
        Style [ TextAlign TextAlignOptions.Center; Padding 40 ]
    ] [
        img [ Src "favicon.png" ]
        h1 [] [ str "SAFE Template" ]
        h2 [] [ str (show model) ]
        button [
            Style [ Margin 5; Padding 10 ]
            OnClick(fun _ -> dispatch Decrement)
        ] [
            str "-"
        ]
        button [
            Style [ Margin 5; Padding 10 ]
            OnClick(fun _ -> dispatch Increment)
        ] [
            str "+"
        ]
    ]

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactBatched "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
