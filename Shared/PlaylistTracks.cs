using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Shared
{
    public sealed class PlaylistTracks
    {
        public Guid PlaylistId { get; set; }
        public Guid SongId { get; set; }
    }
}
