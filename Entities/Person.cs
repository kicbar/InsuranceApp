﻿using System;

namespace InsuranceApp.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Nationality { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public virtual Contract Contract { get; set; }

    }
}
