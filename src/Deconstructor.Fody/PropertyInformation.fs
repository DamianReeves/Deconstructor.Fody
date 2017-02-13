[<AutoOpen>]
module PropertyInformation
open System
open Mono.Cecil
open Mono.Cecil.Cil
open Mono.Cecil.Rocks

let inline hasGetter (prop:PropertyDefinition) =
  match prop.GetMethod with
  | null -> false
  | _ -> true

type PropertyDefinition with
  member this.HasGetter = hasGetter this
