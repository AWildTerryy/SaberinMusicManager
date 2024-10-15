using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistsController(DataDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylist()
        {
            return await _context.Playlists.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            if (playlist == null)
            {
                return BadRequest("Playlist cannot be null.");
            }


            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Playlist>> PutPlaylist(Playlist playlist)
        {
            if (playlist == null)
            {
                return BadRequest("Playlist cannot be null.");
            }

            Playlist _playlist = _context.Playlists.Where(x => x.Id.Equals(playlist.Id)).FirstOrDefault();
            _playlist.Name = playlist.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Playlist>> DeletePlaylist(string id)
        {
            Playlist _playlist = _context.Playlists.Find(Guid.Parse(id));
            _context.Playlists.Remove(_playlist);
            await _context.SaveChangesAsync();
            return _playlist;
        }
    }
}
