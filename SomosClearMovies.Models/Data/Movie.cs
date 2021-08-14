using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SomosClearMovies.Models.Data
{
    /// <summary>
    /// Movies Data Model
    /// </summary>
    public class Movie
    {
        [Key]
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string Genere { get; set; }

        public virtual List<MovieActors> Actors { get; set; }
    }
}
