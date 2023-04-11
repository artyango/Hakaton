using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Hakaton
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Бот запущен");

            Console.WriteLine("Имя пользователя || Сообщение пользователя || Время отправки ");
            Console.ForegroundColor = ConsoleColor.White;


            var client = new TelegramBotClient("6034554077:AAFAZTEnnZUmdD6t3zs3_txpmfrBOJtHBlc");

            client.StartReceiving(Update, Error);




            Console.ReadKey();
        }


        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (update.Message != null)
            {
                if (message.Text != null)
                {

                    switch (message.Text.ToLower())
                    {
                        case "/start":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Добро пожаловать! Я чат-бот, который поможет Вам пользоваться следующими функциями: обучение должностным обязанностям," +
                                " знакомство с офисом и сотрудниками, просмотр информации о компании и продуктах. Для начала выберите одну из функций из меню.");
                            StartButton();
                            break;
                        case "обучение📈":
                            await botClient.SendTextMessageAsync(message.Chat.Id, "...");
                            break;
                               case "офис и сотрудники👥":
                               await  botClient.SendTextMessageAsync(message.Chat.Id, "...");
                             
                            break;
                    }
                }
            }
            async void StartButton()
            {
                string[][] strings = new[] {
                new[]{ "Обучение📈","Офис и сотрудники👥"},
                 new[]{ "Компания и продукты🏬" }
                };

                    ReplyKeyboardMarkup keyboardMarkup = strings;
                  keyboardMarkup.ResizeKeyboard = true;
                  await botClient.SendTextMessageAsync(message.Chat.Id, "Обработано", replyMarkup: keyboardMarkup);
                  return;
            }




        }
        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {

            throw new NotImplementedException();


        }
    }




}