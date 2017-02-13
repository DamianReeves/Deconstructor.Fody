namespace Deconstructor.Fody

open System
open Mono.Cecil
open Mono.Cecil.Cil
open Mono.Cecil.Rocks

type ModuleWeaver() = 

  member val ModuleDefinition:ModuleDefinition = null with get, set

  member val AssemblyResolver:IAssemblyResolver = null with get,set
  member val LogInfo:Action<string> = null with get,set 
  member val LogWarning:Action<string> = null with get,set 
  member val LogError:Action<string> = null with get,set 

  member this.Execute():unit = 
    { Module = this.ModuleDefinition
      Logger = createLogger this.LogInfo this.LogWarning this.LogError    
    } |> execute
    
