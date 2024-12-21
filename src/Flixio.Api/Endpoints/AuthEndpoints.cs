namespace Flixio.Api.Endpoints;

public static class AuthEndpoints
{
    private const string LoginEndpoint = "/login";
    private const string LogoutEndpoint = "/logout";
    private const string RegisterEndpoint = "/register";
    private const string LoginWithTokenEndpoint = "/loginWithToken";
    private const string AuthWithFacebookEndpoint = "/authWithFacebook";
    private const string GetUserEndpoint = "/getUser";
    private const string CreateEndpoint = "/v2/create";
    private const string ReadEndpoint = "/v2/read";

    public static RouteGroupBuilder MapAuthEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost(LoginEndpoint, Login);
        group.MapPost(LogoutEndpoint, Logout);
        group.MapPost(RegisterEndpoint, Register);
        group.MapPost(LoginWithTokenEndpoint, LoginWithToken);
        group.MapPost(AuthWithFacebookEndpoint, AuthWithFacebook);
        group.MapPost(GetUserEndpoint, GetUser);
        group.MapGet(CreateEndpoint, Create);
        group.MapGet(ReadEndpoint, Read);
        
        return group;
    }
    
    private static IResult Login() => Results.Text(StaticUserResults.DefaultUserResponseWithAuthKey);

    private static IResult Logout() => Results.Json(new { success = "true" });

    private static IResult Register([FromBody] RegisterRequest request) => Results.Text(StaticUserResults.DefaultUserResponseWithAuthKey);

    private static IResult LoginWithToken() => Results.Text(StaticUserResults.DefaultUserResponseWithAuthKey);

    private static IResult AuthWithFacebook() => Results.Text(StaticUserResults.DefaultUserResponseWithAuthKey);

    private static IResult GetUser() => Results.Text(StaticUserResults.DefaultUserResponse);

    private static IResult Create() =>
        Results.Ok(new LinkCodeResponse(Constants.DefaultAuthKey, "link", "qrcode"));

    private static IResult Read([AsParameters] LinkRequest _) =>
        Results.Ok(new LinkAuthKeyResponse(Constants.DefaultAuthKey));
}