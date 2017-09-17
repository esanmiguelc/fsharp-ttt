module Tests

open System
open Xunit
open Core.Board

[<Fact>]
let ``it returns an empty board`` () =
    let board = {cells=[{value = None}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}]}
    Assert.Equal(board, emptyBoard)

[<Fact>]
let ``it fills the board with a marker`` () =

    let board = {cells=[{value = Some "X"}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}]}
    Assert.Equal(Ok board, fillBoard emptyBoard "X" 0) 

[<Fact>]
let ``it fills the board with a second marker`` () =

    let board = {cells=[{value = Some "X"}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}; {value = None}; 
                        {value = None}]}

    let updatedBoard = {cells=[{value = Some "X"}; {value = Some "O"}; 
                                {value = None}; {value = None}; 
                                {value = None}; {value = None}; 
                                {value = None}; {value = None}; 
                                {value = None}]}
    Assert.Equal(Ok updatedBoard, fillBoard board "X" 1) 

[<Fact>]
let ``it returns position taken when the position selected is not a valid one`` () =
    Assert.Equal(Error InvalidLocation, fillBoard emptyBoard "X" 10) 

[<Fact>]
let ``it returns position taken when the position selected is not available`` () =
    let board = {cells=[{value = Some "X"}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}]}
    Assert.Equal(Error PositionTaken, fillBoard board "X" 0) 
