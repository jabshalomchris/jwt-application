using JWTApplication;

var header = new Header() { Alg= "HS256", Type ="JWT" };

var claims = new Dictionary<string, string>();
claims.Add("isAdmin", "false");
claims.Add("sub", "User Login");

var payload = new Payload()
{
    Claims = claims
};

string jwtToken = JWTHelper.GenerateToken(header, payload, "abc123");