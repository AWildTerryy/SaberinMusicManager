using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistTracksController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistTracksController(DataDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistTracks>>> GetPlaylist()
        {
            return await _context.PlaylistTracks.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistTracks>> PostPlaylist(PlaylistTracks playlist_track)
        {
            if (playlist_track == null)
            {
                return BadRequest("PlaylistTracks cannot be null.");
            }


            _context.PlaylistTracks.Add(playlist_track);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete()]
        [Route("Delete/{playlist_id}/{song_id}")]
        public async Task<ActionResult<PlaylistTracks>> DeletePlaylistTrack(string playlist_id, string song_id)
        {
            PlaylistTracks _playlist_tracks = _context.PlaylistTracks.Find(Guid.Parse(playlist_id),Guid.Parse(song_id));
            _context.PlaylistTracks.Remove(_playlist_tracks);
            await _context.SaveChangesAsync();
            return _playlist_tracks;
        }
    }
}
