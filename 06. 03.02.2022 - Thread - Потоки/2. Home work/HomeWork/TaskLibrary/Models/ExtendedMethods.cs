using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary.Models
{
    // Класс Расширяющие методы
    public static class ExtendedMethods
    {

        // генерация списка ноутбуков
        public static List<NotebookModel> GetNotebooks(this List<NotebookModel> notebooks, int n = 15) => Enumerable.Repeat(new NotebookModel(), n)
                                                                                                               .Select(m => NotebookModel.GetNotebookModel())
                                                                                                               .ToList();

    }
}
