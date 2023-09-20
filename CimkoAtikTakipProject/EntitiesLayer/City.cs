using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;

namespace EntitiesLayer
{
	/// <summary>
    /// İl
    /// </summary>
	public class City:BaseEntity
	{
		public string Name { get; set; }
		public ICollection<District> District { get; set; }
	}
}
