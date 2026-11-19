# Fusion 16: SourceDocumentId wraps at 32,768

`CompositeResultDocument.DbRow` stores `SourceDocumentId` in 15 bits and masks it silently,
so a result with more than 32,767 source documents reads values from the wrong document.

## Run

```
dotnet run -c Release
```

## Output (HotChocolate.Fusion.Execution 16.7.6)

```
stored 32767, read back 32767
stored 32768, read back 0  <-- wrong source document
stored 43885, read back 11117  <-- wrong source document
```

The project's assembly name matches an `InternalsVisibleTo` entry of
`HotChocolate.Fusion.Execution`, which is the only reason it can construct `DbRow`.
