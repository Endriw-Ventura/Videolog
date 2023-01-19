using System.ComponentModel.DataAnnotations;


namespace Videolog.DTOs
{
    public class CreateVideoDto
    {
    [Required]
    public string description {get; init;}
    [Required]
    public int sizeInBytes {get; init;}
    }
}