using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zwierzoki.DTOs;
using Zwierzoki.Models;
using Zwierzoki.ModelsF;

namespace Zwierzoki.Service
{
    public interface IEfAnimalDbService
    {

        public List<ModelsF.Animal> GetAnimals();

        public string ChangeAnimal(ModelsF.Animal animal);

        public string DeleteAnimal(int idAnimal);

        public List<Enrollment> GetEnrollments();

        public string EnrollStudent(EnrollStudentRequest request);

        public string PromoteStudents(PromoteStudentRequest request);

    }
}