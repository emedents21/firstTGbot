using System;
using Telegram.Bot;
using Telegram;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using System.Threading;
using System.IO;


namespace RSZI42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientBot = new TelegramBotClient("7123172343:AAHuumU845M_vqxO-axLL5VRFKXmcfWyOIY");
            clientBot.StartReceiving(Update, Error);

            Console.ReadLine();
        }

        async static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private static async Task Update(ITelegramBotClient client, Update up, CancellationToken token)
        {
            var message = up.Message;
            if (message.Text != null)
            {

                if (message.Text.ToLower().Contains("hello"))
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "hi bro");
                    return;
                }
                else if (message.Text.ToLower().Contains("who made it"))
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Yehor made this very easy and fastly");
                    return;
                }
                else if (message.Text.ToLower().Contains("send sticker") || message.Text.ToLower().Contains("sticker") || message.Text.ToLower().Contains("wanna sticker"))
                {
                    Message message1 = await client.SendStickerAsync(chatId: message.Chat.Id, sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp"),cancellationToken: token);
                }
            }
            if (message.Photo != null)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Good Picture!");
                return;
            }
            if(message.Text.ToLower().Contains("wanna music"))
            {
                Message message2 = await client.SendAudioAsync(chatId: message.Chat.Id, audio: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3"),cancellationToken: token);
            }
            if(message.Text.ToLower().Contains("create a poll"))
            {
                Message pollMessage = await client.SendPollAsync(chatId: message.Chat.Id, question: "Who is the best?", options: new[]{"Yehor?","Yehorr?"},cancellationToken: token);
            }
            if(message.Text.ToLower().Contains("create a video"))
            {
                await using Stream stream = System.IO.File.OpenRead(@"Z:\\check.mp4");

                Message message3 = await client.SendVideoNoteAsync(
                    chatId: message.Chat.Id,
                    videoNote: InputFile.FromStream(stream),
                    duration: 47,
                    length: 360, // value of width/height
                    cancellationToken: token);
            }

        }
    }
}
