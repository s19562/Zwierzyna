using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zwierzoki.Models;

namespace Zwierzoki.Service
{
    public interface IAnimalService
    {

        public IEnumerable<Animal> GetAnimals(string sortBy);




    }
}
