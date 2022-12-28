using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;

namespace BartenderBot
{
    internal class CommandModule : BaseCommandModule
    {
        private readonly string[] beer = { "Листолюбское особое", "Жирный олух", "Крушитель глифидов", "Аркенстаут", "Усладу Камнестрела", "Андерхилл делюкс", "Сногсшибающий стаут" };
        private readonly ulong bar = 1056273877719851008;

        [Command("налей")]
        public async Task BeerCommand(CommandContext ctx)
        {
            if ((ctx.Channel.Id == bar) && (!ctx.Message.Author.IsBot))
            {
                string author = ctx.Message.Author.Mention;
                Random random = new();
                Console.WriteLine(beer.Length);
                int order = random.Next(beer.Length);
                if (order == 0)
                {
                    await ctx.RespondAsync("*Не шёпотом:* " + author + " заказывает " + beer[order] + "! Повторяю, " + beer[order] + ". Налетайте!");
                }
                else
                {
                    await ctx.RespondAsync(author + " заказывает " + beer[order] + " для всех!");
                }
            } 
        }
        [Command("налей")]
        public async Task BeerCommand(CommandContext ctx, DiscordUser victim)
        {
            if ((ctx.Channel.Id == bar) && (!ctx.Message.Author.IsBot))
            {
                string author = ctx.Message.Author.Mention;
                Random random = new();
                Console.WriteLine(beer.Length);
                int order = random.Next(beer.Length);
                if (order == 0)
                {
                    await ctx.RespondAsync("*Не шёпотом:* " + author + " заказывает " + beer[order] + "! " + victim.Mention + ", наслаждайся вкусом!");
                }
                else
                {
                    await ctx.RespondAsync(author + " заказывает " + beer[order] + " для " + victim.Mention + "!");
                }
            }
        }
    }
}
