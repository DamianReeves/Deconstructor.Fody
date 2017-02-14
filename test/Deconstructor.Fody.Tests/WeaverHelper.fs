[<AutoOpen>]
module FodyTestKit
open System
open System.Reflection
open System.IO
open Fake

let solutionRoot = __SOURCE_DIRECTORY__ @@ "../.." |> directoryInfo
let solutionDir = solutionRoot.FullName

let sdkVersions =
  match directoryExists sdkBasePath with
  | false -> []
  | true ->
    directoryInfo sdkBasePath 
    |> subDirectories
    |> Seq.map (fun dir -> dir.Name)
    |> Seq.filter (fun dir -> dir.StartsWith("v"))
    |> Seq.sortByDescending (fun dir -> (dir.Split('.').[0].Length,dir))
    |> Seq.toList

let allPeVerifyPaths = !!(sdkBasePath + "/**/PEVerify.exe") |> List.ofSeq

let peVerifyToolPath = allPeVerifyPaths |> getNewestTool

let validate assemblyPath = ()

let peverify beforeAssemblyPath afterAssemblyPath =
  log afterAssemblyPath

let getTestAssemblyPath testProj =
  let extension = Path.GetExtension(testProj)
  match extension with
  | "csproj" -> 
    Path.GetFileNameWithoutExtension(testProj)
  | "fsproj" -> 
    Path.GetFileNameWithoutExtension(testProj)
  | _ -> 
    sprintf "Project %s is not of an expected/supported type" testProj
    |> invalidArg "testProj" 

type WeaverHelper(projectPath:string,assembly:Assembly) =
  let beforeAssemblyPath = getTestAssemblyPath projectPath
  let afterAssemblyPath = beforeAssemblyPath.Replace(".dll","2.dll")

