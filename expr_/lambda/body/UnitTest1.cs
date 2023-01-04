using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace nilnul._obj_._TEST_.expr_.lambda.body
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
		}
		public class Dto
		{
			public Guid Id { get; set; }

			public string Name { get; set; }
		}
		public class Validator<T>
		{
			public void AddValidation<TProp>(
				Expression<Func<T, TProp>> propertyExpression,
				Func<TProp, bool> predicate)
			{
				var propertyInfo = (propertyExpression.Body as MemberExpression)?.Member as PropertyInfo;

				if (propertyInfo is null)
					throw new InvalidOperationException("Please provide a valid property expression.");

				// ...
			}

			public bool Validate(T obj)
			{ /* ... */
				throw new NotImplementedException();
			}

			/* ... */
		}

		public static void MethodName()
		{
			var validator = new Validator<Dto>();
			validator.AddValidation(dto => dto.Id, id => id != Guid.Empty);
			validator.AddValidation(dto => dto.Name, name => !string.IsNullOrWhiteSpace(name));

			var isValid = validator.Validate(new Dto { Id = Guid.NewGuid() }); // false

		}
	}
}
