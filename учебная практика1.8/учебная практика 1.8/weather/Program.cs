using System; 
using System.Collections.Generic; 
using System.IO; 
using System.Net;  
using Newtonsoft.Json; 
using Newtonsoft.Json.Linq; 
 
 
namespace weather  
{  
    class Program  
    {  
        static string apiKey = "97b1ed9882e57f6d9e974f21e6b95e17"; 
 
        static string fileOfData = @"D:\учеба\УЧЕБНАЯ ПРАКТИКА\учебная практика 1.8\weather\weather.json"; 
  
        static void Main(string[] args) 
        { 
            JObject cityDefault = CheckDefaultCity(); 
 
            if (cityDefault != null) 
            { 
                Console.WriteLine($"Погода в городе {cityDefault["name"]}"); 
                Console.WriteLine($"Температура: {cityDefault["main"]["temp"]}°F"); 
                Console.WriteLine($"Скорость ветра: {cityDefault["wind"]["speed"]} м/c"); 
                Console.WriteLine($"Влажность: {cityDefault["main"]["humidity"]}%"); 
            } 
            else 
                Console.WriteLine("Нет города по умолчанию"); 
 
            bool isWork = true; 
             
            while (isWork) 
            { 
                Console.WriteLine("-----------\n1 - выбрать город \n2 - выбрать город по умолчанию \n3 - Выход из программы\n-----------");

                int command;

                while (true)
                {
                    string commandStr = Console.ReadLine();

                    if (int.TryParse(commandStr, out command))
                        break;
                    else
                        Console.WriteLine("Неверно! Введите еще раз!");
                }

                switch (command) 
                { 
                    case 1: 
                    { 
                        Console.Write("Введите город: ");
                        string city;
                        
                        while (true)
                        {
                            city = Console.ReadLine();
                            
                            if (city == "")
                            {
                                Console.WriteLine("Введите город:");
                            }
                            else
                                break;
                        }

                        SearchWeatherByCity(city); 
                         
                        break; 
                    } 
                    case 2: 
                    { 
                        Console.Write("Введите город, который будет по умолчанию: "); 
                        string defaultCity; 
                        
                        while (true)
                        {
                            defaultCity = Console.ReadLine();
                            
                            if (defaultCity == "")
                            {
                                Console.WriteLine("Введите город:");
                            }
                            else
                                break;
                        }
 
                        GetDefaultCity(defaultCity); 
                         
                        break; 
                    } 
                    case 3: 
                    { 
                        isWork = false; 
                         
                        break; 
                    } 
                    default: 
                    { 
                        Console.WriteLine("Нет такой команды"); 
 
                        break; 
                    } 
                } 
            } 
        }  
  
        static JObject CheckDefaultCity() 
        { 
            string json = File.ReadAllText(fileOfData); 
 
            JObject weather = (JObject)JsonConvert.DeserializeObject(json); 
 
            return weather; 
        } 
 
        static void GetDefaultCity(string city) 
        { 
            string json = File.ReadAllText(fileOfData); 
 
            JObject weather = (JObject)JsonConvert.DeserializeObject(json);
 
            using (var client = new WebClient()) 
            {
                string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + apiKey; 
                
                var json1 = client.DownloadString(url);

                File.WriteAllText(fileOfData, json1);
            } 
        } 
 
        static void SearchWeatherByCity(string city) 
        { 
            using (var client = new WebClient()) 
            { 
                string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + apiKey; 
                
                var json = client.DownloadString(url);
                
                if (json == "")
                    Console.WriteLine("Город не найден(");
                else
                {
                    JObject weather = (JObject)JsonConvert.DeserializeObject(json);
 
                    Console.WriteLine($"Погода в городе {weather["name"]}"); 
                    Console.WriteLine($"Температура: {weather["main"]["temp"]}°F"); 
                    Console.WriteLine($"Скорость ветра: {weather["wind"]["speed"]} м/c"); 
                    Console.WriteLine($"Влажность: {weather["main"]["humidity"]}%");
                }
            } 
        } 
    }
}