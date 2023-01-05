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
        private readonly ulong bar = Convert.ToUInt64(System.IO.File.ReadAllText("bar.txt"));
        
        [Command("налей")]
        public async Task BeerCommand(CommandContext ctx)
        {
            if (ctx.Channel.Id == bar)
            {
                string author = ctx.Message.Author.Mention;
                Random random = new();
                int order = random.Next(beer.Length);
                string answer;
                if (order == 0)
                {
                    answer = "*Не шёпотом:* " + author + " заказывает " + beer[order] + "! Повторяю, " + beer[order] + ". Налетайте!";
                }
                else
                {
                    answer = author + " заказывает " + beer[order] + " для всех!";
                }
                await ctx.RespondAsync(answer);
            } 
        }
        [Command("налей")]
        public async Task BeerCommand(CommandContext ctx, DiscordUser target)
        {
            if (ctx.Channel.Id == bar)
            {
                string author = ctx.Message.Author.Mention;
                Random random = new();
                int order = random.Next(beer.Length);
                string answer;
                if (order == 0)
                {
                    answer = "*Не шёпотом:* " + author + " заказывает " + beer[order] + "! " + target.Mention + ", наслаждайся вкусом!";
                }
                else
                {
                    answer = author + " заказывает " + beer[order] + " для " + target.Mention + "!";
                }
                await ctx.RespondAsync(answer);
            }
        }
        [Command("налей")]
        public async Task BeerCommand(CommandContext ctx, string target)
        {
            if (ctx.Channel.Id == bar)
            {
                string author = ctx.Message.Author.Mention;
                Random random = new();
                int order = random.Next(beer.Length);
                string answer = "";
                if (target != "мне")
                {
                    answer += "Слова " + author + "сложно разобрать, но, похоже, ";
                }
                if (order == 0)
                {
                    answer += "*кхе-кхе* " + author + " заказывает " + beer[order] + " и выпивает... всё... сам.";
                }
                else
                {
                    answer += author + " заказывает " + beer[order] + " и всё выпивает сам.";
                }
                await ctx.RespondAsync(answer);
            }
        }
    }
}
