using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataAccessLayer;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Sylt.Data
{
    public class JokesAccess
    {
        readonly DataBaseContext _dbContext;

        public JokesAccess(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public async Task<List<Joke>> GetJokes(bool acceptExplicit = false)
        {
            try
            {
                var jokes = await _dbContext.Jokes.ToListAsync();
                if (!acceptExplicit)
                {
                    jokes = jokes.Where(x => x.IsExplicit != true).ToList();
                }

                return jokes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Joke> GetRandomJoke(bool acceptExplicit = false)
        {
            try
            {
                var rnd = new Random();
                var jokes = await GetJokes(acceptExplicit);

                var joke = jokes[rnd.Next(0, jokes.Count)];
                return joke;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        
    }
}
