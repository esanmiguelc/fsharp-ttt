namespace Core

module Types = 
  type Result<'TOk, 'TError> =
  | Ok of value : 'TOk
  | Error of error : 'TError
