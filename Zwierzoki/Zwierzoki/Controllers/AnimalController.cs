using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zwierzoki.DTOs;
using Zwierzoki.Models;
using Zwierzoki.ModelsF;
using Zwierzoki.Service;
using Zwierzoki.Controllers;
using System.ComponentModel;

namespace Zwierzoki.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        readonly IAnimalService _animalService;
        readonly IAddAnimaleService _addAnimaleService;
        readonly EfAnimalDbService _context;

        public AnimalController(IAnimalService service1 , IAddAnimaleService service2, EfAnimalDbService context)
        {
            _animalService = service1;
            _addAnimaleService = service2;
            _context = context;
        }

        /*
        [HttpGet]
        public IActionResult getZwierz(string sortBy)
        {
        
           try
            {
                return Ok(_animalService.GetAnimals(sortBy));
                //ok only bez tej walonej kolejnosci mam w dol only ASC pewnie jakis 
                //kurcze scanner trza dodac zeby wybrac ASC DASC czy jak to bylo 
            }catch(SqlException)
            {
                return BadRequest("parameterz izzz bad maj frend");
            }

        }
        */

        [HttpPost]
        public IActionResult AddAnimal(AddAnimalRequest request)
        {
            try
            {
                return Ok(_addAnimaleService.AddAnimale(request));

                //bedy o duplikacji ? 0.0

            }catch(SqlException)
            { 
                
             return NotFound("blad sql"); //tak wiem ale nwm jak inaczej bo jest 3:45 pewnie trza w tym AddServisie
             
            }

        }
      
         
        //lista animalsów zwrot
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_context.GetAnimals());
        }


       //zmiana animalsa
       [HttpPost]
       public IActionResult ChangeAnimal(ModelsF.Animal animal)
        {
            string s = _context.ChangeAnimal(animal);
            if (s == "error")
                return BadRequest("ni ma zwierzoka");

            return Ok(s);

        }

        [HttpPost("{id}")]
        public IActionResult DeleteAnimal([FromRoute] int idAnimal)
        {

            string s = _context.DeleteAnimal(idAnimal);
            return Ok(s);
        }

        [HttpGet]
        public IActionResult GetEnrollments()
        {
            return Ok(_context.GetEnrollments());
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            var s = _context.EnrollStudent(request);
            return Ok(s);
        }

        [HttpPost("zdaj")]
        public IActionResult PromoteStudents(PromoteStudentRequest request)
        {
            var s = _context.PromoteStudents(request);
            return Ok(s);
        }

    }
}