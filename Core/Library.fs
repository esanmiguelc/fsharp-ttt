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
        let cells = board.cells
        let cell = List.item position cells
        match cell.value with
        | Some _ -> 
          Error PositionTaken
        | None ->
          let newBoard = [{value = Some "X"}; {value = None}; 
                          {value = None}; {value = None}; 
                          {value = None}; {value = None}; 
                          {value = None}; {value = None}; 
                          {value = None}]
          Ok { cells = newBoard }
      with
      | :? ArgumentException -> Error InvalidLocation

