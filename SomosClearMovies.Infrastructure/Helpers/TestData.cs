using SomosClearMovies.Models.Data;
using System.Collections.Generic;

namespace SomosClearMovies.Infrastructure.Helpers
{
    public static class TestData
    {
        public static void AddTestData(MoviesDbContext context)
        {
            context.Movies.AddRange(
                  new Movie
                  {
                      Title = "MY SALINGER YEAR",
                      Genre = "Comedy",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Margaret Qualley"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Sigourney Weaver"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Douglas Booth"
                            }
                        },
                      }
                  },
                  new Movie
                  {
                      Title = "PALMER",
                      Genre = "Drama",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Justin Timberlake"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Juno Temple"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Alisha Wainwright"
                            }
                        },
                      }
                  },
                  new Movie
                  {
                      Title = "PERCY VS GOLIATH",
                      Genre = "Drama",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Pathy Aiyar"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Monique Alvarez"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Adam Beach"
                            }
                        },
                      }
                  },
                  new Movie
                  {
                      Title = "BLACK WIDOW",
                      Genre = "Action",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Scarlett Johansson"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "David Harbour"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Florence Pugh"
                            }
                        },
                      }
                  },
                  new Movie
                  {
                      Title = "AVENGERS: AGE OF ULTRON",
                      Genre = "Adventure",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            IdActor = 10
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Robert Downey Jr."
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Chris Hemsworth"
                            }
                        },
                      }
                  },
                  new Movie
                  {
                      Title = "AVENGERS: INFINITY WAR",
                      Genre = "Adventure",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            IdActor = 10
                        },
                        new MovieActors
                        {
                            IdActor = 13
                        },
                        new MovieActors
                        {
                            IdActor = 14
                        }
                      }
                  },
                  new Movie
                  {
                      Title = "AVENGERS: ENDGAME",
                      Genre = "Adventure",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            IdActor = 10
                        },
                        new MovieActors
                        {
                            IdActor = 13
                        },
                        new MovieActors
                        {
                            IdActor = 14
                        }
                      }
                  },
                  new Movie
                  {
                      Title = "GHOST WORLD",
                      Genre = "Comedy/Drama",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            IdActor = 10
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Thora Birch"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Steve Buscemi"
                            }
                        }
                      }
                  },
                  new Movie
                  {
                      Title = "RICHARD III",
                      Genre = "Drama",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            IdActor = 13
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Ian McKellen"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Annette Bening"
                            }
                        }
                      }
                  },
                  new Movie
                  {
                      Title = "THOR",
                      Genre = "Adventure/Fantasy",
                      Actors = new List<MovieActors> {
                        new MovieActors
                        {
                            IdActor = 14
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Natalie Portman"
                            }
                        },
                        new MovieActors
                        {
                            Actor = new Actor
                            {
                                Name = "Tom Hiddleston"
                            }
                        }
                      }
                  }
              );
            context.SaveChanges();
        }
    }
}
