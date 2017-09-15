namespace Core

module Board =
    type Cell = { value:Option<string> }
    type Board = { cells:list<Cell> }
    type BoardError =
    | InvalidLocation
    | PositionTaken



    let emptyBoard =  
      {cells=[{value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}; {value = None}]}

    val fillBoard : Board -> string -> int -> Result<Board, BoardError>
    let fillBoard board mark position =
      try
        List.item board position
      with
        | ArgumentException -> Error InvalidLocation 
  
  
