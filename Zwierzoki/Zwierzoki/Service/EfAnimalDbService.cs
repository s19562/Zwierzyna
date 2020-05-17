using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zwierzoki.Models;
using Zwierzoki.ModelsF;

namespace Zwierzoki.Service
{
    public class EfAnimalDbService : IEfAnimalDbService
    {

        private readonly s19562Context _context;
      public EfAnimalDbService(s19562Context context)
            {
                _context = context;
            }


        public string ChangeAnimal(ModelsF.Animal animal)
        {

            ModelsF.Animal a = _context.Animal.First(an => an.IdAnimal == animal.IdAnimal);
            a.IdAnimal = animal.IdAnimal;
            a.Name = animal.Name;
            a.Type = animal.Type;
            a.AdmissionDate = animal.AdmissionDate;
            a.IdOwner = animal.IdOwner;
            _context.SaveChanges();

            return "Koniec procedury";
        }

        public string DeleteAnimal(int idAnimal)
        {
            var animal = _context.Animal.FirstOrDefault(a => a.IdAnimal == idAnimal);
            if (animal != null)
            {
                _context.Animal.Remove(animal);
                _context.SaveChanges();
            }
            else
                return "nie ma takiego studenta";

            return "Koniec procedury";
        }

        public List<ModelsF.Animal> GetAnimals()
        {
            return _context.Animal.ToList();
        }
       



    }
}
