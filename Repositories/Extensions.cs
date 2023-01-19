using System.Linq;
using Videolog.DTOs;
using Videolog.Models;

namespace Videolog
{
    public static class Extensions
    {
        public static ServerDto DtoServerConvert(this Server server){
            return new ServerDto{
                id = server.id,
                name = server.name,
                ipAdress = server.ipAdress,
                port = server.port,
                serverVideos = server.serverVideos is not null ? server.serverVideos.Select(video => video.DtoVideoConvert()).ToList() : null
            };
        }

         public static VideoDto DtoVideoConvert(this Video video){
            return new VideoDto{
                id = video.id,
                description = video.description,
                sizeInBytes = video.sizeInBytes
            };
        }
    }
}