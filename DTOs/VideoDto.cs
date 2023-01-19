using System;

namespace Videolog.DTOs
{
 public record VideoDto{
    public Guid id {get; init;}
    public string description {get; init;}
    public int sizeInBytes {get; init;}
    public bool deleted{get; set;}
   }
}