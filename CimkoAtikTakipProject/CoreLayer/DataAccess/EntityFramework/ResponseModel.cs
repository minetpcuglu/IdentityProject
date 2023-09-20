using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DataAccess.EntityFramework
{/// <summary>
 /// Main response class type. You have isSucceded and response properties if needed
 /// </summary>
 /// <typeparam name="T">Class Types</typeparam>
	public class ResponseModel<T>
	{
		/// <summary>
		/// extra message about response
		/// </summary>
		public String Message { get; set; }
		/// <summary>
		/// operation Result 
		/// </summary>
		public bool isSucceeded { get; set; }
		/// <summary>
		/// if  exception exists here it is, null if not exists
		/// </summary>
		public Exception Exception { get; set; }
		/// <summary>
		/// Response data as your request type but Iqueryable for querying custom
		/// </summary>
		public T Data { get; set; }

		public List<ValidationResult> ValidationResults { get; set; }
	}
}
