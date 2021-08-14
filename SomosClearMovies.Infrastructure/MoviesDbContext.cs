using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SomosClearMovies.Models.Data;
using SomosClearMovies.Infrastructure.Interfaces;

namespace SomosClearMovies.Infrastructure
{
    /// <summary>
    /// Movies Database Context
    /// </summary>
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        /// <summary>
        /// Create new instanc of <see cref="MoviesDbContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
        : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActors> MoviesActors { get; set; }

        /// <summary>
        /// Movies Database Context
        /// </summary>
        public MoviesDbContext Context => this;

        /// <summary>
        /// Get Movies
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <param name="genere">Movie Genere</param>
        /// <param name="actorName">Actor Name</param>
        /// <returns>A list of <see cref="MovieActors"/></returns>
        public List<MovieActors> GetMovies(string title, string genere, string actorName)
        {
            // Create a dynamic query to improve SQL Performance
            Expression expr = null;
            var parameter = Expression.Parameter(typeof(MovieActors), "movie");
            if (!string.IsNullOrEmpty(title))
            {
                expr = Contains(
                    expr,
                    Expression.PropertyOrField(
                        Expression.PropertyOrField(
                            parameter,
                            nameof(MovieActors.Movie)),
                        nameof(Movie.Title)),
                    title);
            }

            if (!string.IsNullOrEmpty(genere))
            {
                expr = Contains(
                    expr,
                    Expression.PropertyOrField(
                        Expression.PropertyOrField(
                            parameter,
                            nameof(MovieActors.Movie)),
                        nameof(Movie.Genere)),
                    genere);
            }

            if (!string.IsNullOrEmpty(actorName))
            {
                expr = Contains(
                    expr,
                    Expression.PropertyOrField(
                        Expression.PropertyOrField(
                            parameter,
                            nameof(MovieActors.Actor)),
                        nameof(Actor.Name)),
                    actorName);
            }

            return MoviesActors
                .Include(movie => movie.Movie)
                .Include(actor => actor.Actor)
                .Where(expr != null ?
                    Expression.Lambda<Func<MovieActors, bool>>(expr, parameter) :
                    Expression.Lambda<Func<MovieActors, bool>>(Expression.Constant(true), parameter)
                )
                .ToList();
        }

        /// <summary>
        /// Dynamic Contains Expression SQL Interpretation LIKE %{value}%
        /// </summary>
        /// <param name="expression">String Value</param>
        /// <param name="member">Member Expression</param>
        /// <param name="value">String Value</param>
        /// <returns>A Comparison <see cref="Expression"/></returns>
        private static Expression Contains(Expression expression, MemberExpression member, string value)
        {
            MethodCallExpression body = Expression.Call(typeof(DbFunctionsExtensions).GetMethod(nameof(DbFunctionsExtensions.Like),
                new[] {
                        typeof (DbFunctions), typeof (string), typeof (string)
                }),
            Expression.Constant(EF.Functions),
            member,
            Expression.Constant($"%{value}%"));

            if (expression == null)
            {
                return body;
            }
            else
            {
                return Expression.Or(expression, body);
            }
        }
    }
}
