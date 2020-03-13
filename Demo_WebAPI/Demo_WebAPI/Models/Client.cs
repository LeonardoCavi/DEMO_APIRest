using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_WebAPI.Models
{
    public class Client
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }

        public Client(int? id,string name, int age, string profession)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Profession = profession;
        }
    }
}