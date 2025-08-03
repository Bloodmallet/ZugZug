# ShitShovela

> Every proper Orc starts their career next to an outhouse with a shovel.
> So let's get moving.

This is a batch job to collect data from a source to create tickets in a
ticket system, to finally remove the original data from the source.


## Constraints
- All system interactions happen over network.
- Least amount of complexity as possible. E.g. no supporting 
    systems/components (no persistent storage, no additional messaging
    service, ...)
- No GUI. But console logs are required.
- Don't DOS our systems. Don't flood our ticket system with duplicates. It's
    better to fail/crash than to harm the ticket system.
- Never exceed an externally provided maximum runtime duration.
- Configurations will be provided via environment variables.


## Data Flow
> Move shit from `outhouse` to `dump`.
```mermaid
flowchart LR
    outhouse --> ShitShovela --> dump
```

Move data from `source` into `ticket-system`.
```mermaid
flowchart LR
    source --> console-app --> ticket-system
```

To minimize data loss in case of failed network connections or wrongly set
permissions the following interactions actions happen in order. Also
this action flow should prevent pointlessly created tickets.

```mermaid
sequenceDiagram
    participant S as source
    participant C as console-app
    participant T as ticket-system

    Note over C: Remember your start-up time

    C->>T: Get tickets flagged as "creation-process-ongoing"
    T-->>C: 

    loop FOREACH ticket
        Note over C: Exit program if time ran out
        C->>S: Delete ticket origin data
        S-->>C: 
        C->>T: Remove "creation-process-ongoing" flag from ticket
        T-->>C: 
    end

    loop WHILE data in source
        Note over C: Exit program if time ran out
        C->>S: Get data
        S-->>C: 
        C->>T: Create ticket with "creation-process-ongoing" flag
        T-->>C: 
        C->>S: Delete ticket origin data
        S-->>C: 
        C->>T: Remove "creation-process-ongoing" flag from ticket
        T-->>C: 
    end
```

`console-app` does not have a persistent data storage (db/s3/mount) to reduce 
its complexity by reducing the number of components.
