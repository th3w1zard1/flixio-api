namespace Flixio.Api.Responses;

public record ModalResponse(string Id, string Title, string Message, string ImageUrl, ModalAddonResponse? Addon, string? ExternalUrl);
public record NotificationResponse(string Id, string Title, string Message, string? ExternalUrl);
public record LinkCodeResponse(string Code, string Link, string QrCode);
public record LinkAuthKeyResponse(string AuthKey);