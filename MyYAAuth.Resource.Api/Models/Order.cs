using System;
using System.Collections.Generic;

namespace MyYAAuth.Resource.Api.Models
{
    public class Order
    {
        public Guid UserId { get; set; }
        public int[] BookIds { get; set; }
        
    }
}