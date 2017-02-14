module Deconstructor.Fody.Tests

open Expecto
open Fake

[<EntryPoint>]
let main argv =
  let sampleProjects =
    !! "../../samples/**/*.csproj"
      ++ "../../samples/**/*.fsproj"
  
  printfn "PWD: %s" currentDirectory
  printfn "Solution Root: %O" (solutionRoot.FullName)
  printfn "sdkBasePath: %A" (sdkBasePath)
  printfn "PEVErify Paths: %A" (allPeVerifyPaths)

  printfn "sdkVersions: %A" sdkVersions

  let sortedPaths =
    allPeVerifyPaths
    |> Seq.sortBy (fun p -> p) 
    |> Array.ofSeq 
    |> Array.rev 
    |> Seq.ofArray 

  printfn "PEVErify Paths (sorted): %A" (sortedPaths)

  printfn "PEVErify: %O" (peVerifyToolPath)
  sampleProjects |> List.ofSeq |> printfn "Sample Projects: %A"

  Tests.runTestsInAssembly defaultConfig argv
