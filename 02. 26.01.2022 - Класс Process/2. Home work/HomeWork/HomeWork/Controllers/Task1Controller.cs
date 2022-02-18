using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;       // для работы с процессами

/*
 * Задача 1. Напишите приложение WindowsForms, выбирающее и запускающее 
 * исполняемые файлы типа exe – приложения Windows.
 * 
 * В приложении необходимо вести историю запущенных из нашего приложения 
 * других приложений, отображать имена различных запущенных процессов в 
 * ListView. Выводить подробную информацию о запущенных приложениях в 
 * табличном виде. В историю включать полное имя файла, дату и время 
 * запуска процесса.
*/

namespace HomeWork.Controllers
{
    // Класс Контроллер обработки по заданию 1
    public class Task1Controller
    {
        // процессы
        private List<Process> _processes;

        public List<Process> Processes
        {
            get => _processes;
            set => _processes = value;
        }

        #region Конструкторы

        // конструктор по умолчанию
        public Task1Controller() : this(new List<Process>()) { }


        // конструктор инциализирующий 
        public Task1Controller(List<Process> processes)
        {
            // установка значений
            _processes = processes;
        }

        #endregion

        #region Методы

        // добавление процесса
        public void Add(Process process) => _processes.Insert(0, process);


        // удаление процесса
        public void Remove(Process process) => _processes.Remove(process);


        // удаление процесса по индексу
        public void RemoveAt(int index) => _processes.RemoveAt(index);


        // запуск процесса
        public void ExecuteProcess(Process process)
        {
            // запуск процесса
            process.Start();
        }


        // запуск процесса по индексу
        public void ExecuteProcessAt(int index)
        {
            _processes[index].Start();
        }


        // очистка списка
        public void Clear() => _processes.Clear();

        #endregion
    }
}
