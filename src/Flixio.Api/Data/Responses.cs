namespace Flixio.Api.Data;

public record UserResponse(string Id, string Email, string FullName, string Avatar, bool Anonymous);
public record AuthResponse(string AuthKey, User User);
public record CollectionResponse(List<Descriptor> Addons, DateTime LastModified);
public record SeekLogResponse(bool Success);
public record SkipGapsResponse(string Accuracy, Dictionary<ulong, SkipGaps> Gaps);
public record APIError(string Message, int Code);
public record SuccessResponse(bool Success);
public record ModalResponse(string Id, string Title, string Message, string ImageUrl, ModalAddon? Addon, string? ExternalUrl);
public record NotificationResponse(string Id, string Title, string Message, string? ExternalUrl);
public record LinkCodeResponse(string Code, string Link, string QrCode);
public record LinkAuthKeyResponse(string AuthKey);
public record DatastoreResponse(object Data);