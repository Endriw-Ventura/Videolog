using System;
using System.Collections.Generic;
using System.Linq;
using Videolog.Interfaces;
using Videolog.Models;

namespace Videolog.Repositories
{
    public class InMemoryRepository : IServerRepository
    {
        private readonly List<Server> servers = new(){
        new Server{id = Guid.NewGuid(), name = "ServerTeste1", ipAdress = "192.168.0.111", port = 8080, deleted = false, serverVideos = new(){
            new Video{id = Guid.NewGuid(), description = "videoTeste1", sizeInBytes = 291923, deleted = false },
            new Video{id = Guid.NewGuid(), description = "videoTeste2", sizeInBytes = 291922, deleted = false }
        }},
        new Server{id = Guid.NewGuid(), name = "ServerTeste2", ipAdress = "192.168.0.112", port = 8082, deleted = false}
        };
        public void CreateServer(Server server)
        {
            servers.Add(server);
        }
        public IEnumerable<Server> GetAllServers()
        {
            return servers.Where(s => !s.deleted);
        }
        public Server GetServer(Guid id)
        {
            Server server = servers.Where(s => s.id == id).SingleOrDefault();
            return server;       
        }
        public void UpdateServer(Server server)
        {
            var index = servers.FindIndex(s => s.id == server.id);
            servers[index] = server;
        }
        public void RemoveServer(Server server)
        {
            server.deleted = true;
        }
        public void RecoverServer(Server server)
        {
            server.deleted = false;
        }

        //videos

        public void CreateVideo(Server server, Video video)
        {
            server.serverVideos.Add(video);
        }
        public IEnumerable<Video> GetAllVideos(Server server)
        {
            return server.serverVideos.Where(v => !v.deleted);
        }
        public Video GetVideo(Server server, Guid idVideo)
        {
            Video video = server.serverVideos.Where(v => v.id == idVideo).SingleOrDefault(); 
            return video;      
        }
        public void RemoveVideo(Server server, Guid idVideo)
        {
            Video video = server.serverVideos.Where(v => v.id == idVideo).SingleOrDefault();
            video.deleted = true;
        }
        public void RecoverVideo(Server server, Guid idVideo)
        {
            Video video = server.serverVideos.Where(v => v.id == idVideo).SingleOrDefault();
            video.deleted = false;
        }
    }
}
