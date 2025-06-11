namespace DotNetCoreWebAPIAuthJWT.Models
{
    public class RevokedToken
    {
        public int Id { get; set; }
        public string Jti { get; set; } = string.Empty;
        public DateTime RevokedAt { get; set; }
    }
}
