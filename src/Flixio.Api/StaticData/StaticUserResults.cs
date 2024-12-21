namespace Flixio.Api.StaticData;

public static class StaticUserResults
{
    public static string DefaultUserResponse =>
        """
          {
              "result": {
                  "_id": "67670d7614711aaf5bf0a465",
                  "email": "flixio.user@fake-user.com",
                  "fbId": "",
                  "fullname": "Flixio User",
                  "avatar": "",
                  "anonymous": false,
                  "gdpr_consent": {
                      "marketing": true,
                      "privacy": true,
                      "tos": true,
                      "from": "web"
                  },
                  "taste": null,
                  "lang": "",
                  "dateRegistered": "2020-12-01T00:00:00.000Z",
                  "lastModified": "2020-12-01T00:00:00.000Z",
                  "trakt": {},
                  "stremio_addons": "",
                  "premium_expire": "9999-01-01T00:00:00Z"
              }
          }
          """;
    
    public static string DefaultUserResponseWithAuthKey =>
        """
        {
            "result": {
               "user": {
                   "_id": "67670d7614711aaf5bf0a465",
                   "email": "flixio.user@fake-user.com",
                   "fbId": "",
                   "fullname": "Flixio User",
                   "avatar": "",
                   "anonymous": false,
                   "gdpr_consent": {
                       "marketing": true,
                       "privacy": true,
                       "tos": true,
                       "from": "web"
                   },
                   "taste": null,
                   "lang": "",
                   "dateRegistered": "2020-12-01T00:00:00.000Z",
                   "lastModified": "2020-12-01T00:00:00.000Z",
                   "trakt": {},
                   "stremio_addons": "",
                   "premium_expire": "9999-01-01T00:00:00Z"
               },
               "authKey": "hardcoded-auth-key",
               "success": true
            }
        }
        """;
    
}