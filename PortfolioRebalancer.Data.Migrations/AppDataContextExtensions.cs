namespace PortfolioRebalancer.Data.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq.Expressions;

	public static class AppDataContextExtensions
	{
		public static TEntity[] Add<TEntity>(this AppDataContext context, int count, Func<int, TEntity> factory, Expression<Func<TEntity, object>> identifierExpression = null)
			where TEntity : class, new()
		{
			TEntity[] entities = new TEntity[count];

			for (int index = 0; index < count; index++)
			{
				entities[index] = factory(index);
			}

			DbSet<TEntity> set = context.Set<TEntity>();

			if (identifierExpression != null)
			{
				set.AddOrUpdate(identifierExpression, entities);
			}
			else
			{
				set.AddOrUpdate(entities);
			}

			return entities;
		}
	}
}
