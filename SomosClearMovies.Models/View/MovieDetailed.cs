using System.Collections.Generic;

namespace SomosClearMovies.Models.View
{
    /// <summary>
    /// Movie Detailed View Model
    /// </summary>
    public class MovieDetailed
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public IEnumerable<string> Actors{ get; set; }
    }
}
