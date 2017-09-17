module Tests

open System
open Xunit
open Core.Board

[<Fact>]
let ``it returns an empty board`` () =
    let anEmptyBoard =
        {cells=[{value = None; position = 0};
               {value = None; position = 1};
               {value = None; position = 2};
               {value = None; position = 3};
               {value = None; position = 4};
               {value = None; position = 5};
               {value = None; position = 6};
               {value = None; position = 7};
               {value = None; position = 8};
               {value = None; position = 9}]}

    Assert.Equal(anEmptyBoard, newBoard)

[<Fact>]
let ``it fills the board with a marker`` () =
    let board = {cells=[{value = Some X; position = 0};
                        {value = None; position = 1};
                        {value = None; position = 2};
                        {value = None; position = 3};
                        {value = None; position = 4};
                        {value = None; position = 5};
                        {value = None; position = 6};
                        {value = None; position = 7};
                        {value = None; position = 8};
                        {value = None; position = 9}]}
    Assert.Equal(Ok board, fillBoard newBoard 0)

[<Fact>]
let ``it fills the board with a second marker`` () =
    let board = {cells=[{value = Some X; position = 0};
                        {value = None; position = 1};
                        {value = None; position = 2};
                        {value = None; position = 3};
                        {value = None; position = 4};
                        {value = None; position = 5};
                        {value = None; position = 6};
                        {value = None; position = 7};
                        {value = None; position = 8};
                        {value = None; position = 9}]}

    let updatedBoard = {cells=[{value = Some X; position = 0};
                                {value = Some O; position = 1};
                                {value = None; position = 2};
                                {value = None; position = 3};
                                {value = None; position = 4};
                                {value = None; position = 5};
                                {value = None; position = 6};
                                {value = None; position = 7};
                                {value = None; position = 8};
                                {value = None; position = 9}]}
    Assert.Equal(Ok updatedBoard, fillBoard board 1)


[<Fact>]
let ``it returns position taken when the position selected is not a valid one`` () =
    Assert.Equal(Error InvalidLocation, fillBoard newBoard 10)


[<Fact>]
let ``it returns position taken when the position selected is not available`` () =
    let board = {cells=[{value = Some X; position = 0};
                        {value = None; position = 1};
                        {value = None; position = 2};
                        {value = None; position = 3};
                        {value = None; position = 4};
                        {value = None; position = 5};
                        {value = None; position = 6};
                        {value = None; position = 7};
                        {value = None; position = 8};
                        {value = None; position = 9}]}
    Assert.Equal(Error PositionTaken, fillBoard board 0)
