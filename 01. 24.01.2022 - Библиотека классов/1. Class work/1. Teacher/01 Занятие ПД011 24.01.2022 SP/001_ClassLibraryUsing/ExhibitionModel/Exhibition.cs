using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExhibitionModel
{
    // Выставка картин
    // дата и место проведения выставки
    public class Exhibition
    {
        public int Id { get; set; }

        // дата и место проведения выставки
        public DateTime Date { get; set; }
        public string Place { get; set; }

        // список картин, представленных на выставке
        public virtual ICollection<Picture> Pictures { get; set; }
    } //  class Exhibition
}
