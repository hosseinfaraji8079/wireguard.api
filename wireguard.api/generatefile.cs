using Microsoft.Extensions.Configuration;

namespace wireguard.api
{
    public static class generatefile
    {

        public static async Task generate()
        {
            string content = $"""
                          [Interface]
                          Address = 10.0.0.1/24
                          SaveConfig = true
                          PreUp = 
                          PostUp = 
                          PreDown = 
                          PostDown = 
                          ListenPort = 
                          PrivateKey = AAGh98dWA4t54t32Y+4Fw/KGI3XyQ9XLzVYreDIQAm0=

                          [Peer]
                          PublicKey = EPa3qSY/Xobd5uobkNGa15ot/4e35/MJO4ESaeWRWF4=
                          PresharedKey = {Guid.NewGuid().ToString("N")}
                          AllowedIPs = 10.0.0.2/24
                          """;

            await using (StreamWriter writer = new StreamWriter("/etc/wireguard/test.conf", append: false))
            {
                await writer.WriteLineAsync(content);
            }
        }

    }
}
