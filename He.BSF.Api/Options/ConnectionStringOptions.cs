using System;

namespace He.BSF.Api.Options
{
    public class ConnectionStringOptions
    {
        public Uri Endpoint { get; set; }
        public string AuthKey { get; set; }

        public void Deconstruct(out Uri endpoint, out string authKey)
        {
            endpoint = Endpoint;
            authKey = AuthKey;
        }
    }
}
