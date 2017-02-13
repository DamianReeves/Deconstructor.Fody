[<AutoOpen>]
module Logger

open System

type Logger = {
  LogInfo:Action<string>
  LogWarning:Action<string>
  LogError:Action<string>}

let inline info logger message = logger.LogInfo.Invoke(message)
let inline warn logger message = logger.LogWarning.Invoke(message)
let inline error logger message = logger.LogError.Invoke(message)

let createLogger infoLogger warningLogger errorLogger = 
  { LogInfo = infoLogger;
    LogWarning = warningLogger;
    LogError = errorLogger }
