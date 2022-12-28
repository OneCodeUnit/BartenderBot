using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace BartenderBot
{
    internal class Program
    {
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            DiscordConfiguration config = new();
            config.Token = System.IO.File.ReadAllText("token.txt");
            config.MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug;
            config.Intents = DiscordIntents.All;
            DiscordClient discord = new(config);

            CommandsNextConfiguration commandsConfig = new();
            commandsConfig.StringPrefixes = new[] { "!" };
            CommandsNextExtension commands = discord.UseCommandsNext(commandsConfig);

            commands.RegisterCommands<CommandModule>();

            await discord.ConnectAsync();

            await Task.Delay(Timeout.Infinite);
        }
    }
}