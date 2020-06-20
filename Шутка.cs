using System;

using System.IO;

using System.Net;
using ConsoleApp25;
using Newtonsoft.Json;

namespace JokeApplication

{

    class Program

    {

        static void Main(string[] args)

        {

            //Ссылка на Api запрос

            string url = "https://api.icndb.com/jokes/random";

            string response;

            //Отправляем запрос на сервер для получения JSON ответа

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //Получаем ответ от сервера

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))

            {

                response = streamReader.ReadToEnd();

            }

            //Получаем из JSON после JOKE

            ValueJSON valueJSON = JsonConvert.DeserializeObject<ValueJSON>(response);

            Console.WriteLine("Шутка: {0}", valueJSON.Value.Joke);

            //Чтобы программа сразу не закрывалась

            Console.ReadLine();

        }

    }

}