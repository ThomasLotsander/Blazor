using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataAccess.DataAccessLayer
{
   public class DbInitializer
    {
        public static void Initialize(DataBaseContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Jokes.Any())
                {
                    return;
                }

                var jokes = new Joke[]
                {
                    new Joke()
                    {
                        Premiss = "Vad kallar man en överviktig ekonom?",
                        PunchLine = "Ekonomnom",
                        IsExplicit = false,
                        Explanation = "Nom nom, som att äta mycket mat."
                    }
                };

                foreach (var joke in jokes)
                {
                    context.Jokes.Add(joke);
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                // TODO: Add logging 
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
