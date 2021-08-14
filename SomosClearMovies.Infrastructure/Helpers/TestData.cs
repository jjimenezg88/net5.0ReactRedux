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
                      Genere = "Comedy",
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
                      Genere = "Drama",
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
                      Genere = "Drama",
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
                      Genere = "Action",
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
                      Genere = "Adventure",
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
                      Genere = "Adventure",
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
                      Genere = "Adventure",
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
                      Genere = "Comedy/Drama",
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
                      Genere = "Drama",
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
                      Genere = "Adventure/Fantasy",
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
