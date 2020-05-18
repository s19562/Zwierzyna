using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zwierzoki.DTOs;
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
       
        public List<Enrollment> GetEnrollments()
        {
            var enrollments = _context.Enrollment.ToList();
            return enrollments;
        }

        public string EnrollStudent(EnrollStudentRequest request)
        {
            int res = _context.Studies.First(s => s.Name == request.Studies).IdStudy;

            var idEnrollment = _context.Enrollment.Max(e => e.IdEnrollment) + 1;

            _context.Enrollment.Add(new Enrollment
            {
                IdEnrollment = idEnrollment,
                Semester =0,
                IdStudy = (int)res,
                StartDate = DateTime.Now

            });

            _context.Student.Add(new Student
            {
                IndexNumber = request.IndexNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                IdEnrollment = idEnrollment


            });

            return "Koniec procedury";
        }

        public string PromoteStudents(PromoteStudentRequest request)
        {

            var xd = _context.Studies.First(s => s.Name == request.Studies).IdStudy;
            var xdd = _context.Enrollment.Where(e => e.IdStudy == xd).Where(e => e.Semester == request.Semester);

            if(xdd.Count() < 1)
            {
                return "Nie ma takiego Enrollment";
            }

            foreach(var stu in xdd)
            {
                stu.Semester += 1;
            }

            _context.SaveChanges();
            return "Koniec procedury";

        }
    }
}
