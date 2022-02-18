using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExhibitionModel
{
    // Класс, описывающий картину
    // жанр, название, фамилия и инициалы художника, год создания
    public class Picture
    {
        public int Id { get; set; }

        // жанр картины
        public Genres Genre { get; set; }

        // название картины
        public string Title { get; set; }

        // фамилия и инициалы художника
        public string Artist { get; set; }

        // год завершения картины
        public int Year { get; set; }

        public override string ToString() =>
            $"| {Id,3} | {Genre,-12} | {Title,-20} | {Artist,-20} | {Year,4} |";
    } // class Picture
}
