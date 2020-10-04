using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace DataAccess.Models
{
   public class Joke
    {
        public int ID { get; set; }

        public string Premiss { get; set; }

        public string PunchLine { get; set; }

        public string Explanation { get; set; }

        public bool IsExplicit { get; set; }

    }
}
