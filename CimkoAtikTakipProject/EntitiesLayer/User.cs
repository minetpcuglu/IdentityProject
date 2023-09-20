using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;

namespace EntitiesLayer
{
	public class User:BaseEntity
	{
        public string? Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
