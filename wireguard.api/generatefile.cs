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
                          PrivateKey = AAGh98dWA4t54t32Y+4Fw/KGI3XyQ9XLxVYreDIQAm0=

                          """;

            await using (StreamWriter writer = new StreamWriter("/etc/wireguard/test2.conf", append: false))
            {
                await writer.WriteLineAsync(content);
            }
        }

    }
}
