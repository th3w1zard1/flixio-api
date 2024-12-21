namespace Flixio.Api.Responses;

public class SkipGapsResponse
{
    public string? Accuracy { get; init; }

    public Dictionary<ulong, SkipGaps> Gaps { get; init; } = [];
}

public record SkipGaps(List<SeekEvent> SeekHistory, ulong? Outro);

public record SeekEvent(ulong Records, ulong From, ulong To);