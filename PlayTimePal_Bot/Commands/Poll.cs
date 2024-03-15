using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Net.Models;
using DSharpPlus.SlashCommands;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace PlayTimePal_Bot.Commands
{
	public class Poll : ApplicationCommandModule
	{
		[SlashCommand("poll", "Starts a pole")]
		public async Task PollSL(InteractionContext ctx)
		{
			await ctx.DeferAsync();

			
			int usersAmount = ctx.Channel.Users.Count;
			string[] playersArray = PlayerMessageGenerator(usersAmount);

			var pollMessage = new DiscordEmbedBuilder
			{
				Color = DiscordColor.Blue,
				Title = $"Голосование",
				Description = string.Join("\n", playersArray)
			};
			
			var builder = ButtonGenerator(usersAmount, playersArray);
			builder.AddEmbed(pollMessage);

			var sentPoll = await ctx.Channel.SendMessageAsync(builder);
		}

		private static string[] PlayerMessageGenerator(int usersAmount)
		{
			string[] playerArray = new string[15];

			for (int i = 0; i < usersAmount; i++)
			{
				playerArray[i] = $"Игрок {i + 1}";
			}

			return playerArray;
		}

		private static DiscordMessageBuilder ButtonGenerator(int usersAmount, string[] message)
		{
			var builder = new DiscordMessageBuilder();

			for (int i = 0; i < usersAmount; i++)
			{
				builder.AddComponents(new DiscordButtonComponent(ButtonStyle.Primary, $"{i}_top", message[i]));
			}

			return builder;
		}
	}
}
