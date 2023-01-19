using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Videolog.DTOs;
using Videolog.Interfaces;
using Videolog.Models;

namespace Videolog.Controllers
{
    [ApiController]
    [Route("api")]
    public class ServerController: ControllerBase
    {
        private readonly IServerRepository repository;
        public ServerController(IServerRepository repository){
            this.repository = repository;
        }

        //GET "api/servers"
        [HttpGet("servers")]
        public IEnumerable GetServers(){
            var servers = repository.GetAllServers().Select(server => server.DtoServerConvert());
            return servers;
        }

        //GET "api/servers/{id}"
        [HttpGet("servers/{id}")]
        public ActionResult<ServerDto> GetServer(Guid id){
            Server server = repository.GetServer(id);
            if(server is null){
                return NotFound();
            }
            return Ok(server.DtoServerConvert());
        }

        //POST "api/server"
        [HttpPost("server")]
        public ActionResult<ServerDto> CreateServer(CreateServerDto newServer){
            Server server = new(){
                id = Guid.NewGuid(),
                port = newServer.port,
                ipAdress = newServer.ipAdress,
                name = newServer.name,
                deleted = false,
                serverVideos = null
            };
            repository.CreateServer(server);
            return CreatedAtAction(nameof(GetServer), new {id = server.id}, server.DtoServerConvert());
        }

        [HttpPut("servers/{id}")]
        public ActionResult UpdateServer(Guid id, UpdateServerDto updateServer){
            Server server = repository.GetServer(id);

            if(server is null){
                return NotFound();
            }

            Server newServer  = server with {
                name = updateServer.name,
                port = updateServer.port,
                ipAdress = updateServer.ipAdress,
                deleted = false
            };
            
            repository.UpdateServer(newServer);
            return Ok();
        }

        [HttpDelete("servers/{id}")]
        public ActionResult RemoveServer(Guid id){
            Server server = repository.GetServer(id);
            if(server is null){
               return NotFound();
            }

            repository.RemoveServer(server);
            return Ok();
        }

         [HttpPut("servers/recover/{id}")]
        public ActionResult RecoverServer(Guid id){
            Server server = repository.GetServer(id);
            if(server is null){
               return NotFound();
            }

            repository.RecoverServer(server);
            return Ok();
        }

        //videos
         //GET /api/servers/{serverId}/videos​
        [HttpGet("servers/{idServer}/videos")]
        public IEnumerable GetVideos(Guid idServer){
            Server server = repository.GetServer(idServer);
            var videos = repository.GetAllVideos(server).Select(v => v.DtoVideoConvert());
            return videos;
        }

        //GET "/api/servers/{serverId}/videos/{videoId}"
        [HttpGet("servers/{idServer}/videos/{idVideo}")]
        public ActionResult<VideoDto> GetVideo(Guid idServer, Guid idVideo){
            Server server = repository.GetServer(idServer);
            Video video = repository.GetVideo(server, idVideo);
            if(video is null){
                return NotFound();
            }
            return Ok(video.DtoVideoConvert());
        }

        //POST "api/server"/api/servers/{serverId}/videos​
        [HttpPost("servers/{idServer}/videos")]
        public ActionResult<CreateVideoDto> CreateVideo(Guid idServer, CreateVideoDto newVideo){
            Server server = repository.GetServer(idServer);

            if(server is null){
                return NotFound("Server not found");    
            }

            Video video = new(){
                id = Guid.NewGuid(),
                description = newVideo.description,
                sizeInBytes = newVideo.sizeInBytes,
                deleted = false
            };
            repository.CreateVideo(server, video);
            return CreatedAtAction(nameof(GetVideo), new {idServer = server.id, idVideo = video.id}, video.DtoVideoConvert());
        }

        [HttpDelete("servers/{idServer}/videos/{idVideo}")]
        public ActionResult RemoveVideo(Guid idServer, Guid idVideo){
            Server server = repository.GetServer(idServer);
            if(server is null){
               return NotFound("Server not found");
            }
            repository.RemoveVideo(server, idVideo);
            return Ok();
        }

         [HttpPut("servers/{idServer}/videos/{idVideo}")]
        public ActionResult RecoverVideo(Guid idServer, Guid idVideo){
            Server server = repository.GetServer(idServer);
            if(server is null){
               return NotFound("Server not found");
            }

            repository.RecoverVideo(server, idVideo);
            return Ok();
        }


    }
}