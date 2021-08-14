using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomosClearMovies.Models.Data
{
    /// <summary>
    /// Movie Actors Data Model
    /// </summary>
    public class MovieActors
    {
        [Key]
        public int IdMovieActors { get; set; }
        public int IdMovie { get; set; }
        public int IdActor { get; set; }

        [ForeignKey(nameof(IdMovie))]
        public virtual Movie Movie { get; set; }

        [ForeignKey(nameof(IdActor))]
        public virtual Actor Actor { get; set; }
    }
}
