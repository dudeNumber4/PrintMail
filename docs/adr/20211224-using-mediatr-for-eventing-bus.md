# Using MediatR for Eventing / Bus

- Status: [draft | proposed | rejected | accepted | deprecated | … | superseded by [xxx](yyyymmdd-xxx.md)] <!-- optional -->
- Deciders: [list everyone involved in the decision] <!-- optional -->
- Date: [YYYY-MM-DD when the decision was last updated] <!-- optional. To customize the ordering without relying on Git creation dates and filenames -->
- Tags: [space and/or comma separated list of tags] <!-- optional -->

Technical Story: [description | ticket/issue URL] <!-- optional -->

## Context and Problem Statement

We want to have a way to be able to submit commands at the service level and have any number of subscribers listen to those commands.  In other words, a simple bus.

## Decision Drivers

- Need something simple, easy to use that gets the job done.

## Considered Options

- MediatR: Simple eventing library.
- Nothing: just directly couple layers.
- EventFlow: fuggetabowtit; WAY too complex
- Distributed eventing: We're talking about eventing within the service here.  As additional services come online and traffic increases between them, this may certainly be an option.

## Decision Outcome

Chosen option: "MediatR", because it's simple, easy to use, but powerful and fulfills the requirements.

### Positive Consequences <!-- optional -->

- Service layer decoupled from domain layer or any other subscriber.  This makes the service layer simpler, easier to test, more difficult to introduce bugs in.
- Service layer can issue commands, and any number of subscribers.
- This forms a pattern that keeps the overall service simpler to work on.
- This enables further patterns such as CQRS (just a variation of the same idea), when needed.

### Negative Consequences <!-- optional -->

- I'm sure there are some...

## Pros and Cons of the Options <!-- optional -->

### Usage
TODO: Give example usage
