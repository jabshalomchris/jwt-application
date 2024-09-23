using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JWTApplication
{
    public class Payload
    {
        public Dictionary<string, string> Claims { get; set; }
    }
}
