using System;
using System.Collections.Generic;

namespace Zwierzoki.ModelsF
{
    public partial class Produkt
    {
        public int IdProdukt { get; set; }
        public string Nazwa { get; set; }
        public int? Cena { get; set; }
        public int? IdKategoria { get; set; }
    }
}
