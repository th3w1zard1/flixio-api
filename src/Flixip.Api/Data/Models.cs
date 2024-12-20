namespace Flixio.Api.Data;

public record Descriptor(string Name, string ManifestUrl);

public record User(string Id, string Email);

public record SeriesInfo(string Name, int Season, int Episode);

public record SeekLog(ulong From, ulong To);

public record SkipGaps(List<SeekEvent> SeekHistory, ulong? Outro);

public record SeekEvent(ulong Records, ulong From, ulong To);

public record ModalAddon(string Name, string ManifestUrl);

public record DatastoreCommand(string Type, object Payload);