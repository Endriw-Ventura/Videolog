using System;

namespace Videolog.Models
{
 public record Video{
    public Guid id {get; init;}
    public string description {get; init;}
    public bool deleted{get; set;}
    public int sizeInBytes {get; init;}
   }
}
//    videodata = Base64.encodeToString(objByteArrayOS.toByteArray(), Base64.DEFAULT);
