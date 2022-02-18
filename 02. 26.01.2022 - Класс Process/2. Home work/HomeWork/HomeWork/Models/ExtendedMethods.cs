using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;       // для работы с процессами

namespace HomeWork.Models
{
    // Класс Расширяющие методы
    public static class ExtendedMethods
    {
        // получение элемента ListViewItem для вывода информации о процессе
        public static ListViewItem GetListViewItem(this Process process)
        {
            // элемент 
            ListViewItem item = new ListViewItem(process.ProcessName);

            // добавление значений
            item.SubItems.AddRange(new[] { process.StartInfo.FileName, process.StartTime.ToString() });

            return item;
        }
    }
}
