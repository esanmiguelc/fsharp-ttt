namespace Core

module Types = 
  type Result<'TOk, 'TError> =
  | Ok of value : 'a
  | Error of error : 'b
