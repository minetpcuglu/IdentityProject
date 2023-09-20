using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
	public class UserDTO : BaseEntityDTO
	{
		public string? Username { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
	}
}
