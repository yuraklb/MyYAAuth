using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYAAuth.Resource.Api.Models
{
    public class  Book
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public string Author {get;set;}
        public decimal Price {get;set;}
    }
}