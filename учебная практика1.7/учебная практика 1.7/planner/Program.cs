using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace planner
{
    internal class Program    
    {
        private static string FileOfPlanner { get; set; }
        
        public static void Main(string[] args)       
        {
            FileOfPlanner = @"D:\учеба\УЧЕБНАЯ ПРАКТИКА\учебная практика 1.7\planner\planner.json";
            
            bool isWork = true;
            
            string allCommands = "\n------------------\n0 - Вывести все задачи \n1 - Добавить задачу \n2 - Удалить задачу \n3 - Редактировать задачу \n4 - Вывести задачи на сегодня \n5 - Вывести задачи на завтра \n6 - Вывести задачи на неделю \n7 - Выход из программы \n------------------";
            
            while (isWork)
            {
                Console.WriteLine(allCommands);
                
                string inputCommandStr = Console.ReadLine();
                
                int inputCommand = GetINtFromString(inputCommandStr);
                
                switch (inputCommand)       
                {
                    case 0:                   
                    {
                        List<Task> allTasks = ReadAllPlanner();
                        
                        Console.WriteLine("Задачи:");
                        
                        for (int i = 0; i < allTasks.Count; i ++)
                            Console.WriteLine($"{i + 1}. {allTasks[i].Name} - {allTasks[i].Description}  {allTasks[i].DateOfTask}");
                        
                        /*foreach (var task in allTasks) 
                            Console.WriteLine(task.Name + "-" + task.Description + " " + task.DateOfTask);*/

                        break;
                    }
                    case 1:
                    {
                        Console.Write("Введите задачу: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите описание задачи: ");
                        string description = Console.ReadLine();

                        while (true)
                        {

                            Console.Write("Введите дату в формате ГГГГ-ММ-ДД: ");

                            string date = Console.ReadLine();

                            DateTime date1 = ConvertToDateTime(date);

                            DateTime date2 = new DateTime();

                            if (date1 == date2)
                                Console.WriteLine("Неправильно введена дата!");
                            else
                            {
                                Task newTask = new Task(name, description, date);

                                SaveToPlanner(newTask);

                                Console.WriteLine("Успешно!");
                                
                                break;
                            }
                        }
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Введите название задачи:");
                        string nameForDeletion = Console.ReadLine();
                        if (nameForDeletion == "")             
                            Console.WriteLine("Нет такой задачи");
                        else                        
                        {
                            bool result = DeleteFromPlanner(nameForDeletion);
                            if (result)                               
                                Console.WriteLine("Успешно!");
                            else                               
                                Console.WriteLine("Ошибка!");
                        }                       
                        break;
                    }                   
                    case 3:
                    {                       
                        Console.WriteLine("Введите номер задачи, которую хотите отредактировать:");
                        string indexForEdit = Console.ReadLine();

                        if (indexForEdit == "")                           
                            Console.WriteLine("Нет такой задачи");
                        else                        
                        {
                            bool result = EditPlanner(indexForEdit);
                            
                            if (result)                               
                                Console.WriteLine("Успешно!");
                            else                                
                                Console.WriteLine("Ошибка!");
                        }
                        break;
                    }
                    case 4: 
                    { 
                        Console.WriteLine("Задачи на сегодня:"); 
                        
                        OutputTasksForToday(); 
                        
                        break; 
                    } 
                    case 5: 
                    { 
                        Console.WriteLine("Задачи на завтра:"); 
                        
                        OutputTasksForTomorrow(); 
                        
                        break; 
                    } 
                    case 6: 
                    { 
                        Console.WriteLine("Задачи на неделю:"); 
                        
                        OutputTasksForWeek(); 
                        
                        break; 
                    } 
                    case 7: 
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
 
        static int GetINtFromString(string inputStr) 
        { 
            int input = -1; 
            try 
            { 
                input = int.Parse(inputStr); 
            } 
            catch (FormatException) 
            { 
            } 
            return input; 
        } 
 
        static void SaveToPlanner(Task task) 
        { 
            List<Task> allCurrentTasks = ReadAllPlanner();
            
            allCurrentTasks.Add(task); 
 
            string serializedTasks = JsonConvert.SerializeObject(allCurrentTasks); 
             
            File.WriteAllText(FileOfPlanner, serializedTasks);
           
        } 
 
        static bool EditPlanner(string indexForEdit) 
        { 
            List<Task> allCurrentTasks = ReadAllPlanner();

            bool isWork = true; 
            
            while (isWork)
            {
                int index;

                if (int.TryParse(indexForEdit, out index))
                {
                    index--;
                    if (index < allCurrentTasks.Count && index >= 0)
                    {
                        bool isWork1 = true;

                        while (isWork1)
                        {
                             Console.WriteLine(
                                "--------\nЧто вы хотите изменить? \n0 - название \n1 - описание \n2 - дата \n3 - остановить редактирование\n--------");
                             int command;
                             
                             while (true)
                             {
                                 string commandStr = Console.ReadLine();

                                 if (int.TryParse(commandStr, out command))
                                     break;
                                 else
                                    Console.WriteLine("Неправильно! Введите цифру!");
                             }

                             switch (command)
                             {
                                 case 0:
                                 {
                                     Console.WriteLine("Введите новое название задачи:");

                                     allCurrentTasks[index].Name = Console.ReadLine();

                                     string output = Newtonsoft.Json.JsonConvert.SerializeObject(allCurrentTasks,
                                         Newtonsoft.Json.Formatting.Indented);
                                     
                                     File.WriteAllText(FileOfPlanner, output);

                                     break; 
                                 }
                                 case 1:
                                 {
                                     Console.WriteLine("Введите новое описание задачи:");

                                     allCurrentTasks[index].Description = Console.ReadLine();
                                     
                                     string output = Newtonsoft.Json.JsonConvert.SerializeObject(allCurrentTasks,
                                         Newtonsoft.Json.Formatting.Indented);
                                     
                                     File.WriteAllText(FileOfPlanner, output);
                                    
                                     break;
                                 }
                                 case 2:
                                 {
                                     while (true)
                                     {
                                         Console.Write("Введите новую дату в формате ГГГГ-ММ-ДД: ");

                                         allCurrentTasks[index].DateOfTask = Console.ReadLine();

                                         DateTime date1 = ConvertToDateTime(allCurrentTasks[index].DateOfTask);
                                        
                                         DateTime date2 = new DateTime();

                                         if (date1 == date2)
                                             Console.WriteLine("Неправильно введена дата!");
                                         else
                                             break;
                                     }
                                     
                                     string output = Newtonsoft.Json.JsonConvert.SerializeObject(allCurrentTasks,
                                         Newtonsoft.Json.Formatting.Indented);
                                     
                                     File.WriteAllText(FileOfPlanner, output);
                                     
                                     break;
                                 }
                                 case 3:
                                 {
                                     isWork = false;
                                     
                                     isWork1 = false;

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
                    else
                        Console.WriteLine("Нет задачи с таким номером! Введите еще раз");
                }
                else 
                    Console.WriteLine("Неправильно! Введите еще раз");
                if (isWork != false)
                    indexForEdit = Console.ReadLine();
            }
            return true;
        } 
 
        static void SaveToPlanner(List<Task> tasks) 
        { 
            string serializedTasks = JsonConvert.SerializeObject(tasks); 
             
            File.WriteAllText(FileOfPlanner, serializedTasks); 
        } 
 
        static bool DeleteFromPlanner(string name) 
        { 
            List<Task> allCurrentTasks = ReadAllPlanner();
            
            bool result = false;
                
            Task taskForDeletion = allCurrentTasks.FirstOrDefault(t => t.Name == name);

            if (taskForDeletion != null)
            {
                allCurrentTasks.Remove(taskForDeletion);

                SaveToPlanner(allCurrentTasks);

                result = true;
            }

            return result;
        } 
         
        static List<Task> ReadAllPlanner() 
        { 
            string json = File.ReadAllText(FileOfPlanner);

            if (json == "")
            {
                List<Task> currentTasks1 = new List<Task>();

                return currentTasks1;
            }
            else
            {
                List<Task> currentTasks = JsonConvert.DeserializeObject<List<Task>>(json);

                return currentTasks;
            }
        } 
 
        static void OutputTasksForToday() 
        { 
            List<Task> tasks = ReadAllPlanner();

            foreach (var task in tasks)
            {
                DateTime time = ConvertToDateTime(task.DateOfTask);
                
                if (time == DateTime.Today) 
                    Console.WriteLine(task.Name + "-" + task.Description);
            }
        } 
         
        static void OutputTasksForTomorrow() 
        { 
            List<Task> tasks = ReadAllPlanner();
            
            foreach (var task in tasks)
            {
                DateTime time = ConvertToDateTime(task.DateOfTask);
                if (time == DateTime.Today.AddDays(1))
                    Console.WriteLine(task.Name + "-" + task.Description);
            }
        }
        //☃ 
        static void OutputTasksForWeek() 
        { 
            List<Task> tasks = ReadAllPlanner();
            
            
            DateTime endOfWeek = DateTime.Today.AddDays(7);

            foreach (var task in tasks)
            {
                DateTime time = ConvertToDateTime(task.DateOfTask);
                if (time <= endOfWeek && time >= DateTime.Today) 
                    Console.WriteLine(task.Name + "-" + task.Description);
            }
        }

        static DateTime ConvertToDateTime(string time)
        {
            DateTime timeOfTask;
            
            if (DateTime.TryParse(time, out timeOfTask))
                return timeOfTask;
            else
            {
                Console.WriteLine("Неправильно!");
                
                return timeOfTask;
            }
        }
    } 
 
    class Task 
    { 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string DateOfTask { get; set; } 
 
        public Task(string name, string description, string dateOfTask) 
        { 
            Name = name; 
            Description = description; 
            DateOfTask = dateOfTask; 
        }
    }
}