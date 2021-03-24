namespace GiraffeByMiddleware

open Giraffe
open Microsoft.AspNetCore.Http

module Composition =

  type Root = { Test: int -> string }

  let build setting = { Test = fun x -> $"%i{x}%s{setting}" }


module HttpHandler =

  let webApp (root: Composition.Root): HttpFunc -> HttpContext -> HttpFuncResult =
    choose [ route "/ping" >=> text "pong from Giraffe"
             route "/" >=> text $"Hello World! Test from F# :) || {root.Test 5}" ]
