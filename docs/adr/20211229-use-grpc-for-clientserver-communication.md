# Use gRPC for client/server communication

- Status: accepted
- Deciders: Just me for now
- Tags: API,HTTP2

Technical Story: [description | ticket/issue URL] <!-- optional -->

## Context and Problem Statement

Common decision currently needed is whether to use traditional REST or gRPC

## Decision Drivers <!-- optional -->

- HTTP2 (assuming we can use it)
- Efficiency: gRPC is much more efficient than text-based HTTP1
- Flexibility: gRPC allows flexible clients, better type matching between client/server, etc.

## Considered Options

- REST
- gRPC

## Decision Outcome

Chosen option: gRPC

### Positive Consequences <!-- optional -->

- Efficient communication
- More testable code (less plumbing code)

### Negative Consequences <!-- optional -->

- Must currently copy/paste proto files between server and clients.  Tooling should improve.

## Links <!-- optional -->

- [gRPC in .Net](https://www.infoq.com/articles/getting-started-grpc-dotnet) <!-- example: Refined by [xxx](yyyymmdd-xxx.md) -->
