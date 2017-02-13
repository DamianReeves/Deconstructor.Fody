[<AutoOpen>]
module MethodInformation

open Mono.Cecil

let inline isDeconstructor (methodDef:MethodDefinition) = 
  match methodDef.Name with
  | "Deconstruct" -> true
  | _ -> false

type MethodDefinition with
  member this.IsDeconstructor = isDeconstructor this
