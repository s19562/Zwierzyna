using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zwierzoki.Models
{
    public class Animal
    {
        //jas w zadaniu trzeba tutaj chyba zmienic po prostu nazwy zeby bylo 1:1 
        //jak w poleceniu np "LastNameOfOwner" ale mi sie juz nie chce teraz too late
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string LastName { get; set; }
       
    }
}
