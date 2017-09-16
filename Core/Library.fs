namespace Core

open System

module Board =
    type Cell = { value:Option<string> }
    type Board = { cells:list<Cell> }
    type BoardError =
    | InvalidLocation
    | PositionTaken

    let emptyBoard : Board =
      {cells=[{value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}]}

    let fillBoard (board : Board) (mark : string) (position : int) : Result<Board, BoardError> =
      try
        let item = List.item position board.cells
        Ok {cells=[{value = Some "X"}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}]}
      with
      | :? ArgumentException -> Error InvalidLocation

