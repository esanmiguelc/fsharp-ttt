module Tests

open System
open Xunit
open Core.Board

[<Fact>]
let ``it returns an empty board`` () =
    let board: Board = Map.ofList [(0, None); (1, None); (2, None);
                                   (3, None); (4, None); (5, None);
                                   (6, None); (7, None); (8, None)]
    Assert.Equal<Board>(board, emptyBoard 3)

[<Fact>]
let ``it fills the board with a marker`` () =
    let board = Map.ofList [(0, Some X); (1, None); (2, None);
                            (3, None); (4, None); (5, None);
                            (6, None); (7, None); (8, None)]
    Assert.Equal(Ok board, fillBoard (emptyBoard 3) 0)

[<Fact>]
let ``it fills the board with a second marker`` () =
    let board = Map.ofList [(0, Some X); (1, None); (2, None);
                             (3, None); (4, None); (5, None);
                             (6, None); (7, None); (8, None)]
    let expectedBoard = Map.ofList [(0, Some X); (1, Some O); (2, None);
                            (3, None); (4, None); (5, None);
                            (6, None); (7, None); (8, None)]

    Assert.Equal(Ok expectedBoard, (fillBoard board 1))

[<Fact>]
let ``it returns invalid position if the position requested is not within the correct range`` () =
    Assert.Equal(Error InvalidPosition, fillBoard (emptyBoard 3) -1)

[<Fact>]
let ``it returns position taken if the position requested is already taken by a player`` () =
    let board = Map.ofList [(0, Some X); (1, None); (2, None);
                            (3, None); (4, None); (5, None);
                            (6, None); (7, None); (8, None)]
    Assert.Equal(Error PositionTaken, fillBoard board  0)

[<Fact>]
let ``Determines when the game is over with a tie`` () =
    Assert.Equal(1,2)

// playGame (emptyBoard 3) 0
// let playGame board position =
//     match (fillBoard (emptyBoard 3) position) with
//     (Ok newBoard) ->
//         // playGame board getNewPositon
//     Tie board ->
        // print board
        // print it's a tie!
//      // do something with a tie
//     Winner mark ->
//         // do something with the winner
//     (Error _) ->
//      You messed up this way, fix it
//      // deal with error

// (fillBoard) |> isGameOver
// whoWon
// match (fillBoard oldBoard position) with
//     (Ok board) ->
//         // get next move
//     Tie ->
//      // do something with a tie
//     Winner mark ->
//         // do something with the winner
//     (Error _) ->
//      // deal with error
