using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Net.Models;
using DSharpPlus.SlashCommands;
using System.Runtime.CompilerServices;

namespace PlayTimePal_Bot.Commands
{
	public class Poll : ApplicationCommandModule
	{
		[SlashCommand("poll", "Starts a pole")]
		public async Task PollSL(InteractionContext ctx)
		{
			await ctx.DeferAsync();

			var count = ctx.Channel.Users.Count;

			DiscordEmoji[] emojiOptions = { DiscordEmoji.FromName(ctx.Client, ":one:"),
											DiscordEmoji.FromName(ctx.Client, ":two:"),
											DiscordEmoji.FromName(ctx.Client, ":three:"),
											DiscordEmoji.FromName(ctx.Client, ":four:") };

			string optionsDescription = $"{emojiOptions[0]} | Игрок 1 \n" +
										$"{emojiOptions[1]} | Игрок 2 \n" +
										$"{emojiOptions[2]} | Игрок 3 \n" +
										$"{emojiOptions[3]} | Игрок 4 \n";

			var pollMessage = new DiscordEmbedBuilder
			{
				Color = DiscordColor.Blue,
				Title = $"Голосование",
				Description = optionsDescription
			};

			var sentPoll = await ctx.Channel.SendMessageAsync(embed : pollMessage);
			foreach (DiscordEmoji e in emojiOptions)
			{
				await sentPoll.CreateReactionAsync(e);
			}

		}
	}
}
