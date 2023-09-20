using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;

namespace EntitiesLayer
{
    /// <summary>
    /// Atık Kod
    /// </summary>
	public class WasteCode:BaseEntity
	{
        public string Name { get; set; }
        public string? Description { get; set; }

		public ICollection<WasteForm> WasteForm { get; set; }
	}
}
