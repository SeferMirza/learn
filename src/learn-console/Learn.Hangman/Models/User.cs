﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman.Models
{
    public class User
    {
        public string Name { get; set; }
        public User()
        {

        }
        public User(string name)
        {
            Name = name;
        }
    }
}
