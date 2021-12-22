using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPIs.Models
{
    public class Filme
    {
        [Required(ErrorMessage ="O campo titulo é Obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é Obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30,ErrorMessage = "O genero não pode passar de 10 caracteres")]
        public string Genero { get; set; }
        [ Range(1,1800, ErrorMessage = "A duração  é entre zero e 1800s")]
        public int Duracao { get; set; }
        public int Id { get; set; }
    }
}
