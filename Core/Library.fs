namespace Core

module Board =
    type PlayerMark =
    | X
    | O
    type Cell = Option<PlayerMark>
    type Board = Map<int,Cell>
    type BoardError =
    | InvalidPosition
    | PositionTaken

    let emptyBoard (size: int) : Board =
      [0 .. (size * size - 1)] |> List.map (fun position -> (position,  None)) |> Map.ofList
 
    let private isWithinRange(board: Board, position: int) : bool =
      Map.exists (fun key v -> key = position) board

    let private findPlayerMark (board: Board) =
      let spacesTaken = Map.filter (fun _ v -> v <> None) board
      let numSpacesTaken = Map.toList spacesTaken |> List.length
      if numSpacesTaken % 2 = 0 then X else O

    let fillBoard (board: Board) (position: int) : Result<Board, BoardError> =
      if isWithinRange(board, position) then
        match (Map.find position board) with
          | None ->
            Ok (board |> Map.add position (Some (findPlayerMark board)))
          | _ ->
            Error PositionTaken
      else
        Error InvalidPosition
