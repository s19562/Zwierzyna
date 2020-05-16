using System;
using System.Collections.Generic;

namespace Zwierzoki.ModelsF
{
    public partial class Pracownik
    {
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? Pensja { get; set; }
        public int? IdMiasto { get; set; }
    }
}
