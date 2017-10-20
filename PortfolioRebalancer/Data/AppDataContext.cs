namespace PortfolioRebalancer.Data
{
	using System;
	using System.Data.Entity;

	public class AppDataContext : DbContext
	{
		public const int IdLength = 36;

		public static string NewId()
		{
			return Guid.NewGuid().ToString();
		}

		public AppDataContext()
			: base("name=PortfolioRebalancer")
		{
		}

		public virtual DbSet<HouseholdModel> HouseholdModels { get; set; }

		public virtual DbSet<Household> Households { get; set; }

		public virtual DbSet<ModelMap> ModelMaps { get; set; }

		public virtual DbSet<PortfolioModel> PortfolioModels { get; set; }

		public virtual DbSet<Portfolio> Portfolios { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<HouseholdModel>()
			//	.HasMany(e => e.Households)
			//	.WithRequired(e => e.HouseholdModel)
			//	.HasForeignKey(e => e.HouseholdModelId)
			//	.WillCascadeOnDelete(false);

			//modelBuilder.Entity<HouseholdModel>()
			//	.HasMany(e => e.ModelMaps)
			//	.WithRequired(e => e.HouseholdModel)
			//	.WillCascadeOnDelete(false);

			//modelBuilder.Entity<Household>()
			//	.HasMany(e => e.Portfolios)
			//	.WithOptional(e => e.Household)
			//	.HasForeignKey(e => e.HouseholdId);

			//modelBuilder.Entity<PortfolioModel>()
			//	.HasMany(e => e.ModelMaps)
			//	.WithRequired(e => e.PortfolioModel)
			//	.WillCascadeOnDelete(false);
		}
	}
}
