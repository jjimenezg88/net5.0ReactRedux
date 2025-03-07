﻿namespace SomosClearMovies.Models.View
{
    /// <summary>
    /// Get Movies Request View Model
    /// </summary>
    public class GetMoviesRequest
    {
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public string ActorName { get; set; }
    }
}
