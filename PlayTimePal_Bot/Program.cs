using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using PlayTimePal_Bot.Commands;
using PlayTimePal_Bot.config;

public class Program
{
	private static DiscordClient Client { get; set; }
	private static CommandsNextExtension Commands {  get; set; }

	public static async Task Main(string[] args)
	{
		var jsonReader = new JSONReader();
		await jsonReader.ReadJSON();

		var discordConfig = new DiscordConfiguration()
		{
			Intents = DiscordIntents.All,
			Token = jsonReader.token,
			TokenType = TokenType.Bot,
			AutoReconnect = true
		};

		Client = new DiscordClient(discordConfig);

		Client.Ready += Client_Ready;

		
		var slashCommandConfig = Client.UseSlashCommands();
		slashCommandConfig.RegisterCommands<Poll>();




		await Client.ConnectAsync();
		await Task.Delay(-1);
	}

	private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
	{
		return Task.CompletedTask;
	}
}