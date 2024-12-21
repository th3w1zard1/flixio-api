namespace Flixio.Api.Requests;

public record AuthRequest(string Email, string Password, bool Facebook);
public record RegisterRequest(string Email, string Password, string GDPRConsent);
public record LogoutRequest(string AuthKey);
public record SeekLogRequest(string OsId, string ItemId, SeriesInfoResponse SeriesInfo, string StHash, ulong Duration, List<SeekLogResponse> SeekHistory, List<ulong> SkipOutro);
public record SkipGapsRequest(string AuthKey, string OsId, string ItemId, SeriesInfoResponse SeriesInfo, string StHash);
public record DataExportRequest(string AuthKey);
public record EventsRequest(string AuthKey, List<Dictionary<string, object>> Events);
public record GetModalRequest(DateTime Date);
public record GetNotificationRequest(DateTime Date);
public record LinkRequest(string Code);
