using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleTask03
{
    class Program
    {
        /*
         * Некоторые свойства класса Task
         * AsyncState: возвращает объект состояния задачи
         * CurrentId : возвращает идентификатор текущей задачи
         * Exception : возвращает объект исключения, возникшего при выполнении задачи
         * Status    : возвращает статус задачи 
         * 
         */
        static void Main(string[] args) {
            Console.Title = "Занятие 14.02.2022 - работа с пулом потоков в TPL";

            // Запуск задачи с параметрами
            // DemoParams();


            // Изучения возможных состояний задачи (на примере t5)
            DemoTaskState();

            Console.Title = "Нажмите любую клавишу для выхода...";
            Console.ReadKey();
        } // Main

        // Запуск задачи с параметрами
        private static void DemoParams() {
            // Как вызвать метод с параметром - выполнить вызов в исполняемом методе Task
            // () => DisplayMessage("вызов метода с параметрами") - исполняемый метод Task
            string str = "вызов метода с параметрами";
            Task task1 = new Task(() => DisplayMessage(str));
            task1.Start();

            // та же техника передачи параметров допустима и для Thread
            // new Thread(() => DisplayMessage(str)).Start();
            task1.Wait();
        } // DemoParams
        

        // Изучение состояний задачи
        private static void DemoTaskState() {
            // TaskFactory - нестатический класс для создания задач
            // TaskFactory tf = new TaskFactory();
            // Task t5 = tf.StartNew(Display);

            Task t5 = new Task(Display);
            try {
                // вывод состояния задачи
                // WaitingToRun     - ожидание запуска
                // Running          - работает
                // RanToCompletion  - работа завершена
                Console.WriteLine($"{t5.Id,2}: {t5.Status}");

                t5.Start();
                Console.WriteLine($"{t5.Id,2}: {t5.Status}");

                while (!t5.IsCompleted) {
                    Console.WriteLine($"{t5.Id,2}: {t5.Status}");
                    Thread.Sleep(100);
                } // while

                Console.WriteLine($"{t5.Id,2}: {t5.Status}");

                t5.Wait(); // для гарантии завершения приложения 
            }
            catch (Exception ex)  {
                Console.WriteLine($"{t5.Id,2}: {t5.Status}");
            }
        } // DemoTaskState


        // метод, выполняющийся в потоке Task
        static void Display() {
            Console.WriteLine($"Id задачи: {Task.CurrentId, 2}. Display - старт.");
            
            // для демонстрации статуса Faulted
            // throw new Exception("!!!!");
            
            Thread.Sleep(1000); // имитация длительной обработки
            Console.WriteLine($"Id задачи: {Task.CurrentId, 2}. Display - стоп.");
        } // Display

        // этот метод вызвается из Task, как пример вызова с передачей параметров
        static void DisplayMessage(string message) {
            Console.WriteLine($"Id задачи: {Task.CurrentId, 2}. DisplayMessage: Сообщение \"{message}\".");
            Thread.Sleep(1000); // имитация длительной обработки
            Console.WriteLine($"Id задачи: {Task.CurrentId, 2}. DisplayMessage: стоп.");
        } // DisplayMessage
    } // class Program
}
