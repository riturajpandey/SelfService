using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService.Model
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public string State { get; set; }
        public string Image { get; set; }
        public Details Details { get; set; }
    }
    public class Details
    {
        public string Kategori { get; set; }
        public string Merke { get; set; }
        public string Modell { get; set; }
        public string Farge { get; set; }
        public string Dusør { get; set; }
        public string Årsmodell { get; set; }
        public string Sted { get; set; }
        public string Dato { get; set; }
        public string Fot { get; set; }
        public string HIN { get; set; }
        public string Hestekrefter { get; set; }
    }
}