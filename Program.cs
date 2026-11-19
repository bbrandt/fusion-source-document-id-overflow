using HotChocolate.Fusion.Text.Json;

foreach (var sourceDocumentId in new[] { 32_767, 32_768, 43_885 })
{
    var row = new CompositeResultDocument.DbRow(
        ElementTokenType.String,
        location: 42,
        sizeOrLength: 7,
        sourceDocumentId: sourceDocumentId);

    Console.WriteLine(
        $"stored {sourceDocumentId}, read back {row.SourceDocumentId}"
        + (row.SourceDocumentId == sourceDocumentId ? "" : "  <-- wrong source document"));
}
