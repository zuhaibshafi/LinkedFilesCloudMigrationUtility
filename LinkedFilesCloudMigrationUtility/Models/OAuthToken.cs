namespace LinkedFilesCloudMigrationUtility.Models
{
    /// <summary>
    /// The LinkedFiles  class represents LinkedFiles in the BQE Galaxy Data Model Framework.
    /// </summary>

    public class OAuthToken
    {
        public OAuthToken(string token, string secret,string _ResourceBaseUrl = null, string _AuthBaseUrl=null)
        {
            Token = token;
            Secret = secret;
            ResourceBaseUrl = _ResourceBaseUrl;
            AuthBaseUrl = _AuthBaseUrl;

        }

        public string Token { get; set; }//private set;

        public string Secret { get; set; }//private set;

        public string ResourceBaseUrl { get; set; }//private set;
        public string AuthBaseUrl { get; set; }//private set;
    }

    
}