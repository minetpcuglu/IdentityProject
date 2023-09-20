using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.DataAccess.EntityFramework
{
	public static class DbContextExtention
	{
		public static List<ValidationResult> CheckValidation(this DbContext context)
		{
			var entities = (from entry in context.ChangeTracker.Entries()
							where entry.State == EntityState.Modified || entry.State == EntityState.Added
							select entry.Entity);

			var validationResults = new List<ValidationResult>();
			var errorMessage = new StringBuilder();
			foreach (var entity in entities)
			{
				if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
				{
				}
			}

			return validationResults.Count == 0 ? null : validationResults;

		}
	}
}
