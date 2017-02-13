[<AutoOpen>]
module TypeInformation
open System
open Mono.Cecil

let inline hasDeconstructor (typeDef:TypeDefinition) = 
  typeDef.Methods |> Seq.exists isDeconstructor

let inline getReadableProperties (typeDef:TypeDefinition) = query {
  for prop in typeDef.Properties do
  where (prop.HasGetter)
  select prop
}  


type TypeDefinition with
  member this.HasDeconstructor = hasDeconstructor this
  member this.ReadableProperties = getReadableProperties this

