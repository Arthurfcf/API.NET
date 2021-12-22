using FilmesAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            return CreatedAtAction(nameof(ListaDeUmFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult ListaDeFilmes()
        {
            return Ok(filmes);

        }
        [HttpGet("{id}")]
        public IActionResult ListaDeUmFilme(int id)
        {
            Filme filme = filmes.FirstOrDefault(Filme => Filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
        
        
        
    }

}

