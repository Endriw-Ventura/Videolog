
using System;
using System.Collections.Generic;
using Videolog.Models;

namespace Videolog.Interfaces
{
public interface IServerRepository
    {
        IEnumerable<Server> GetAllServers();
        Server GetServer(Guid id);
        void CreateServer(Server server);
        void UpdateServer(Server server);
        void RemoveServer(Server server);
        void RecoverServer(Server server);
        IEnumerable<Video> GetAllVideos(Server server);
        Video GetVideo(Server server, Guid idVideo);
        void CreateVideo(Server server, Video video);
        void RemoveVideo(Server server, Guid idVideo);
        void RecoverVideo(Server server, Guid idVideo);
    }
}