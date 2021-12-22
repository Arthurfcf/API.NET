using FilmesAPIs.Data;
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
        private FilmesContext _context;

        public FilmeController(FilmesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListaDeUmFilme), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> ListaDeFilmes()
        {
            return _context.Filmes;

        }
        [HttpGet("{id}")]
        public IActionResult ListaDeUmFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(Filme => Filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
        
        
        
    }

}

