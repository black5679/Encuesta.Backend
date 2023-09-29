using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Backend.Domain.Base
{
    public class JwtModel
    {
        public required string Secret { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public int AccessExpiration { get; set; }
        public required string EncryptKey { get; set; }
    }
}
