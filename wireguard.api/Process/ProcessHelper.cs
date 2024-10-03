using System.Diagnostics;

namespace wireguard.api;

public static class ProcessHelper
{
    public static async Task<string> ExecuteWgShow()
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "wg",
            Arguments = "show",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            UserName = "root"
        };

        try
        {
            using Process process = Process.Start(psi);
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error: " + error);
            }

            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine("Output: " + output);
            }
            else
            {
                Console.WriteLine("No output received from wg show command.");
            }

            return output;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }

        return "";
    }

    public static async Task<string> StatusWireguard(bool status, string? name = "")
    {
        string up = "up ";
        string down = "down ";
        
        string? arguments = (status ? up : down) + name;
        
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "wg-quick",
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            UserName = "root"
        };
        
        try
        {
            using Process process = Process.Start(psi);
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error: " + error);
            }

            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine("Output: " + output);
            }
            else
            {
                Console.WriteLine("No output received from wg show command.");
            }

            return output;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }

        return "";
    }
}