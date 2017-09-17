namespace Core

open System

module Board =
    type PlayerMark =
    | X
    | O
    type Cell = { value:Option<PlayerMark>; position:int }
    type Board = { cells:list<Cell> }
    type BoardError =
    | InvalidLocation
    | PositionTaken

    let public emptyBoard : Board = 
      { cells = [ for pos in 0 .. 9 -> {value = None; position = pos } ] }

    let private getMark (board: Board) : PlayerMark =
      List.filter (fun cell -> cell.value = None) board.cells 
      |> List.length 
      |> (fun count -> count % 2 = 0) 
      |> (fun value -> if value then X else O)

    let public fillBoard (board : Board) (position : int) : Result<Board, BoardError> =
      try
        let cells = board.cells
        let cell = List.find (fun i -> i.position = position) cells
        match cell.value with
        | Some _ -> 
          Error PositionTaken
        | None ->
          let updateCell = List.filter (fun cell -> cell.position <> position) >> 
                           List.append  [{ value = Some (getMark board); position = position }] >> 
                           List.sortBy (fun c -> c.position)
          Ok { cells = updateCell board.cells }
      with
      | :? System.Collections.Generic.KeyNotFoundException -> Error InvalidLocation

