using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Net.Models;
using DSharpPlus.SlashCommands;
using System.Reflection.Metadata;
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
			var playersList = PlayerMessageGenerator(usersAmount);

			var pollMessage = new DiscordEmbedBuilder
			{
				Color = DiscordColor.Blue,
				Title = $"Голосование",
				Description = string.Join("\n", playersList)
			};
			
			var builder = ButtonGenerator(usersAmount, playersList);
			builder.AddEmbed(pollMessage);

			var sentPoll = await ctx.Channel.SendMessageAsync(builder);


			ButtonHandler(ctx);
		}

		private void ButtonHandler(InteractionContext ctx)
		{
			Dictionary<string, int> buttonClicks = new Dictionary<string, int>();

			ctx.Client.ComponentInteractionCreated += async (s, e) =>
			{
				var clickedButtonId = e.Interaction.Data.CustomId; 

				if (clickedButtonId.StartsWith("button")) 
				{	
					if (!buttonClicks.ContainsKey(clickedButtonId))
					{
						buttonClicks[clickedButtonId] = 1;
					}
					else
					{
						buttonClicks[clickedButtonId]++;
					}

					// Delete the button click message only for the user who clicked the button
					await e.Interaction.CreateFollowupMessageAsync(new DiscordFollowupMessageBuilder()
									.WithContent("Your vote has been counted.")
									.AsEphemeral(true));

				}
				else if (clickedButtonId == "end_poll")
				{
					string result = "Poll results:\n";
					foreach (var optionId in buttonClicks.Keys)
					{
						result += $"{optionId}: {buttonClicks[optionId]}\n";
					}
					await ctx.Channel.SendMessageAsync(result);
				}

			};
		}

		private static List<string> PlayerMessageGenerator(int usersAmount)
		{
			List<string> playerList = new List<string>();

			for (int i = 0; i < usersAmount; i++)
			{
				playerList.Add($"Игрок {i + 1}");
			}

			return playerList;
		}


		private static DiscordMessageBuilder ButtonGenerator(int usersAmount, List<string> message)
		{
			var builder = new DiscordMessageBuilder();

			for (int i = 0; i < usersAmount; i++)
			{
				builder.AddComponents(new DiscordButtonComponent(ButtonStyle.Primary, $"button{i}", message[i]));
			}
			builder.AddComponents(new DiscordButtonComponent(ButtonStyle.Danger, "end_poll", "End Poll"));
			return builder;
		}
	}
}
