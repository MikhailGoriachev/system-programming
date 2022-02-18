using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskLibrary.Utilities;        // утилиты

/*
 * Поля класса Ноутбук для ремонта:
 *      - наименование устройства
 *      - модель
 *      - тип процессора
 *      - объем оперативной памяти
 *      - емкость накопителя
 *      - диагональ экрана
 *      - описание неисправности
 *      - фамилия и инициалы владельца
 */

/*
 *b)	создание коллекции заявок на ремонт ноутбуков (наименование устройства,
 *      модель, тип процессора, объем оперативной памяти, емкость накопителя,
 *      диагональ экрана, описание неисправности, фамилия и инициалы владельца),
 *      сериализация этой коллекции при первом запуске; десериализация, 
 *      перемешивание и сериализация при последующих запусках. Формат файла 
 *      данных – JSON
*/

namespace TaskLibrary.Models
{
    // Класс Данные о ноутбуке для ремонта
    public class NotebookModel
    {
        // наименование устройства
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }


        // модель
        private string _model;

        public string Model
        {
            get => _model;
            set => _model = value;
        }


        // тип процессора
        private string _processor;

        public string Processor
        {
            get => _processor;
            set => _processor = value;
        }


        // объем оперативной памяти
        private int _ram;

        public int Ram
        {
            get => _ram;
            set => _ram = value;
        }


        // емкость накопителя
        private int _battery;

        public int Battery
        {
            get => _battery;
            set => _battery = value;
        }


        // диагональ экрана
        private double _diagonal;

        public double Diagonal
        {
            get => _diagonal;
            set => _diagonal = value;
        }


        // описание неисправности
        private string _defect;

        public string Defect
        {
            get => _defect;
            set => _defect = value;
        }


        // фамилия и инициалы владельца
        private string _owner;

        public string Owner
        {
            get => _owner;
            set => _owner = value;
        }


        #region Методы

        // фабричный метод
        public static NotebookModel GetNotebookModel() =>
            new NotebookModel
            {
                Name        = Utils.GetNameTablet(),
                Model       = Utils.GetModel(),
                Battery     = Utils.GetRand(3,7) * 1000,
                Diagonal    = Utils.GetDiagonal(),
                Defect      = Utils.GetDefect(),
                Owner       = Utils.GetPerson(),
                Processor   = Utils.GetProcessor(),
                Ram         = Utils.GetRam()
            };

        #endregion
    }
}
