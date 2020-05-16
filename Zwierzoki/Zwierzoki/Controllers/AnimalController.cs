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

namespace Zwierzoki.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        readonly IAnimalService _animalService;
        readonly IAddAnimaleService _addAnimaleService;
        readonly s19562Context _context;

        public AnimalController(IAnimalService service1 , IAddAnimaleService service2, s19562Context context)
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
      
         
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Animal.ToList());
        }


       



    }
}