using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zwierzoki.DTOs;

namespace Zwierzoki.Service
{
    public interface IAddAnimaleService
    {
        //tutaj by mogl byc jakis fajniejszy typ zwracany zeby chociaz pokazal cos :0
        public string AddAnimale(AddAnimalRequest request);
    }
}
