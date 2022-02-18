using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;   // для класса Process 

namespace ProcessInfo
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 27.01.2022: получение информации о процессе";

            /*
            // Класс Process - набор свойств и методов для работы с процессами
            Process process1 = new Process {
                StartInfo = {FileName = "notepad.exe", Arguments = "..\\..\\Program.cs"}

            };

            // ожидание завершения процесса, но не срабатывает на calc.exe 
            // т.е. на приложениях Windows Store
            // process1.StartInfo.FileName = "calc.exe";

            process1.Start();
            Console.WriteLine($"Размер виртуальной памяти процесса: {process1.VirtualMemorySize64/1024/1024, 2:n} МБайт");
            Console.WriteLine($"Приоритет процесса                : {process1.BasePriority, 2:n}");
            Console.WriteLine($"Класс приоритета процесса         : {process1.PriorityClass}");
        
            
            // работает при перенапавлении стандартного потока
            // process1.StandardInput.WriteLine("--------- Привет, мир! ---------");

            // метод ожидания завершения процесса
            // (не работает с приложениями Windows Store)
            
            process1.WaitForExit();
            Console.Clear();
            */

            
            // вывод информации обо всех процессах ОС
            IEnumerable<Process> processes = Process.GetProcesses();
            foreach (var process in processes) {
                Console.WriteLine($"{process.Id, 6} | {process.ProcessName, -35} | потоков: {process.Threads.Count, 3} | {process.VirtualMemorySize64/1024, 20:n}k |");

                // завершение некоторых процессов
                // if (process.ProcessName.ToLower().Contains("totalcmd")) process.Kill();
                // if (process.ProcessName.ToLower().Contains("explorer")) process.Kill();
            } // foreach
            
            Console.WriteLine("\nКонец работы");
        } // Main
    } // class Program
}
