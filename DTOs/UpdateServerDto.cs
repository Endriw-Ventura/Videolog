using System.ComponentModel.DataAnnotations;

namespace Videolog.DTOs
{
    public record UpdateServerDto
    {
        [Required]
        public string name {get; set;}
        [Required]
        public string ipAdress {get; set;}
        [Required]
        public int port {get; set;}
        public bool deleted{get; set;}
    }
}