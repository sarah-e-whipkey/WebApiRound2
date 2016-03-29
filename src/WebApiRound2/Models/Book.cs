﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRound2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set;}
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
    }
}
