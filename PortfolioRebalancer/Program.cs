namespace PortfolioRebalancer
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;
	using AutoMapper;
	using AutoMapper.Configuration;
	using Data;
	using ViewModels;
	using AutoMapper.QueryableExtensions;

	class Intermediary<TViewModelType>
	{
		private readonly DbContext _dbContext;

		public Intermediary(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public TViewModelType[] Where(Expression<Func<TViewModelType, bool>> predicate)
		{
			IQueryable<TViewModelType> query = CreateQuery();
			return query.Where(predicate).ToArray();
		}

		public TViewModelType First()
		{
			return Call(Queryable.First);
		}

		public TViewModelType First(Expression<Func<TViewModelType, bool>> predicate)
		{
			return Call(Queryable.First, predicate);
		}

		public TViewModelType FirstOrDefault()
		{
			return Call(Queryable.FirstOrDefault);
		}

		public TViewModelType FirstOrDefault(Expression<Func<TViewModelType, bool>> predicate)
		{
			return Call(Queryable.FirstOrDefault, predicate);
		}

		public TViewModelType Single()
		{
			return Call(Queryable.Single);
		}

		public TViewModelType Single(Expression<Func<TViewModelType, bool>> predicate)
		{
			return Call(Queryable.Single, predicate);
		}

		public TViewModelType SingleOrDefault()
		{
			return Call(Queryable.SingleOrDefault);
		}

		public TViewModelType SingleOrDefault(Expression<Func<TViewModelType, bool>> predicate)
		{
			return Call(Queryable.SingleOrDefault, predicate);
		}

		public TViewModelType[] Get(Func<IQueryable<TViewModelType>, IQueryable<TViewModelType>> predicate)
		{
			var query = CreateQuery();
			return predicate(query).ToArray();
		}

		public TViewModelType Get(Expression<Func<IQueryable<TViewModelType>, TViewModelType>> predicateExpression)
		{
			var query = CreateQuery();
			var predicate = predicateExpression.Compile();
			return predicate.Invoke(query);

		}

		private IQueryable<TViewModelType> CreateQuery()
		{
			var viewModelType = typeof(TViewModelType);

			var targetMap = Mapper.Configuration.GetAllTypeMaps().Single(map => map.DestinationType == viewModelType);
			var dbSet = _dbContext.Set(targetMap.SourceType);

			return dbSet/*.AsNoTracking()*/.ProjectTo<TViewModelType>();
		}

		private TViewModelType Call(Func<IQueryable<TViewModelType>, Expression<Func<TViewModelType, bool>>, TViewModelType> func, Expression<Func<TViewModelType, bool>> predicate)
		{
			IQueryable<TViewModelType> query = CreateQuery();
			return func(query, predicate);
		}

		private TViewModelType Call(Func<IQueryable<TViewModelType>, TViewModelType> func)
		{
			IQueryable<TViewModelType> query = CreateQuery();
			return func(query);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Mapper.Initialize(Config);

			//XXX<PortfolioViewModel>(models => models.Where);
			//YYY<PortfolioViewModel>(models => models.Where(p => p.Household != null));
			//ZZZ<PortfolioViewModel>(models => models.FirstOrDefault(p => p.Household != null));

			using (DbContext db = new AppDataContext())
			{
				var intermediary = new Intermediary<PortfolioViewModel>(db);

				
		
				var portfolios = intermediary.Get(models => models.Where(model => model.HouseholdId != null));
				//var portfolio = intermediary.Get(models => models.FirstOrDefault(model => model.HouseholdId != null));

				//var portfolios = intermediary.Get(models => model.Household != null);
				//var portfolio = intermediary.Get(models => model.Household != null);
			}
		}

		private static void XXX<T>(Expression<Func<IQueryable<T>, /**/ Func<Expression<Func<T, bool>>, IQueryable<T>> /**/>> z)
		{
			Func<IQueryable<T>, Expression<Func<T, bool>>, IQueryable<T>> y = Queryable.Where;
		}

		private static void YYY<T>(Expression<Func<IQueryable<T>, /**/ IQueryable<T>/**/>> z)
		{
			var zBody = z.Body;
			if (zBody.NodeType == ExpressionType.Call)
			{
				var methodCall = (MethodCallExpression)zBody;

			}
		}

		private static void ZZZ<T>(Expression<Func<IQueryable<T>, /**/ T/**/>> z)
		{
		}

		private static void Config(IMapperConfigurationExpression config)
		{
			config.CreateMap(typeof(Portfolio), typeof(PortfolioViewModel));
			config.CreateMap(typeof(Household), typeof(HouseholdViewModel));
		}
	}
}
