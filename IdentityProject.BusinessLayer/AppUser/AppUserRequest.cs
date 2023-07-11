﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProject.BusinessLayer.AppUser
{
	public class AppUserRequest
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public string Username { get; set; }
		public string Mail { get; set; }
		public string Surname { get; set; }
		public string District { get; set; }
		public string City { get; set; }
		public string ImageUrl { get; set; }
		public int ConfirmCode { get; set; }
	}
}
