namespace Core

open System

module Board =
    type Cell = { value:Option<string>; position:int }
    type Board = { cells:list<Cell> }
    type BoardError =
    | InvalidLocation
    | PositionTaken

    let public emptyBoard : Board = 
      { cells = [ for pos in 0 .. 9 -> {value = None; position = pos } ] }

    let public fillBoard (board : Board) (mark : string) (position : int) : Result<Board, BoardError> =
      try
        let cells = board.cells
        let cell = List.find (fun i -> i.position = position) cells
        match cell.value with
        | Some _ -> 
          Error PositionTaken
        | None ->
          let updateCell = List.filter (fun cell -> cell.position <> position) >> 
                           List.append  [{ value = Some mark; position = position }] >> 
                           List.sortBy (fun c -> c.position)
          Ok { cells = updateCell board.cells }
      with
      | :? System.Collections.Generic.KeyNotFoundException -> Error InvalidLocation

