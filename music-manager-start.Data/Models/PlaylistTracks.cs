using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace music_manager_starter.Data.Models
{
    public sealed class PlaylistTracks
    {
        public Guid PlaylistId { get; set; }
        public Guid SongId { get; set; }
    }
}