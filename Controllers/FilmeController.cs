using FilmesAPIs.Data;
using FilmesAPIs.Dtos;
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
        public IActionResult AdicionaFilme([FromBody] FilmeDto filmeDto)
        {
            Filme filme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Diretor = filmeDto.Diretor,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao
            };
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
                ListaFilmesDto filmesDto = new ListaFilmesDto
                {
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Duracao = filme.Duracao,
                    id = filme.Id,
                    Genero = filme.Genero,
                    HoraConsulta = DateTime.Now
                };
                return Ok(filme);
            }
            return NotFound();
        }
        
        [HttpPut("{id}")]
        public IActionResult Atualizarfilme(int id, [FromBody] UpdateFilmeDto FilmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme ==null)
            {
                return NotFound();
            }
            filme.Titulo = FilmeDto.Titulo;
            filme.Diretor = FilmeDto.Diretor;
            filme.Genero = FilmeDto.Genero;
            filme.Duracao = FilmeDto.Duracao;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletafilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
        
    }

}

