namespace Flixio.Api.Data;

public record AuthRequest(string Email, string Password, bool Facebook);
public record RegisterRequest(string Email, string Password, string GDPRConsent);
public record LogoutRequest(string AuthKey);
public record AddonCollectionGetRequest(string AuthKey, bool Update);
public record AddonCollectionSetRequest(string AuthKey, List<Descriptor> Addons);
public record SeekLogRequest(string OsId, string ItemId, SeriesInfo SeriesInfo, string StHash, ulong Duration, List<SeekLog> SeekHistory, List<ulong> SkipOutro);
public record SkipGapsRequest(string AuthKey, string OsId, string ItemId, SeriesInfo SeriesInfo, string StHash);
public record DataExportRequest(string AuthKey);
public record EventsRequest(string AuthKey, List<object> Events);
public record GetModalRequest(DateTime Date);
public record GetNotificationRequest(DateTime Date);
public record LinkRequest(string Code);
public record DatastoreRequest(string AuthKey, string Collection, DatastoreCommand Command);
