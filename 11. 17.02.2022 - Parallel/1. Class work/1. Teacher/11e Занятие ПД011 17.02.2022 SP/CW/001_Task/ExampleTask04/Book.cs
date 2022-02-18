using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleTask04
{
    // пример ссылочного типа
    public class Book
    {
        public string Title  { get; set; }
        public string Author { get; set; }
        public int    Price  { get; set; }

        public override string ToString() =>
            $"Автор {Author}, название \"{Title}\", цена {Price}";
    } // class Book
}
