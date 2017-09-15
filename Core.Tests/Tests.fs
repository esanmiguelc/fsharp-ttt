module Tests

open System
open Xunit
open Core.Board

[<Fact>]
let ``it returns an empty board`` () =
    let board = {cells=[{value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}]}
    Assert.Equal(board, emptyBoard)

[<Fact>]
let ``it fills the board with a marker`` () =
    let board = {cells=[{value = Some "X"}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}]}
    Assert.Equal(Ok board, fillBoard emptyBoard "X" 0) 
