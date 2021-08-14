using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SomosClearMovies.Models.Data
{
    /// <summary>
    /// Actors Data Model
    /// </summary>
    public class Actor
    {
        [Key]
        public int IdActor { get; set; }
        public string Name { get; set; }

        public virtual List<MovieActors> Movies { get; set; }
    }
}
