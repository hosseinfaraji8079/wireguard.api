using Microsoft.Extensions.Configuration;

namespace wireguard.api
{
    public static class generatefile
    {

        public static async Task generate()
        {
            string content = $"""
                          [Interface]
                          Address = 12.0.0.1/24
                          SaveConfig = true
                          PreUp = 
                          PostUp = 
                          PreDown = 
                          PostDown = 
                          ListenPort = 25255
                          PrivateKey = AAGh98dWA4t54t32Y+4Fw/KGI3XyQ9XLxVYreDIQAm0=

                          """;

            await using (StreamWriter writer = new StreamWriter("/etc/wireguard/wg0.conf", append: false))
            {
                await writer.WriteLineAsync(content);
            }
        }

    }
}
