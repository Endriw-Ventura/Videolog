using System;
using System.Collections.Generic;

namespace Videolog.Models
{
 public record Server{
    public Guid id {get; init;}
    public string name {get; set;}
    public string ipAdress {get; set;}
    public int port {get; set;}
   public bool deleted{get; set;}
    public List<Video> serverVideos {get; set;}
   }
}
