namespace PortfolioRebalancer.Data
{
	using System.Data.Entity;

	public class AppDataContext : DbContext
	{
		public AppDataContext()
			: base("name=AppDataContext")
		{
		}

		public virtual DbSet<Household> Households { get; set; }
		public virtual DbSet<Model> Models { get; set; }
		public virtual DbSet<Portfolio> Portfolios { get; set; }
		public virtual DbSet<Position> Positions { get; set; }
		public virtual DbSet<Regulation> Regulations { get; set; }
		public virtual DbSet<Rule> Rules { get; set; }
		public virtual DbSet<Stock> Stock { get; set; }

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Model>()
		//		.HasMany(e => e.Households)
		//		.WithRequired(e => e.Model)
		//		.WillCascadeOnDelete(false);

		//	modelBuilder.Entity<Model>()
		//		.HasMany(e => e.Rules)
		//		.WithRequired(e => e.Model)
		//		.WillCascadeOnDelete(false);

		//	modelBuilder.Entity<Portfolio>()
		//		.HasMany(e => e.Positions)
		//		.WithRequired(e => e.Portfolio)
		//		.WillCascadeOnDelete(false);

		//	modelBuilder.Entity<Regulation>()
		//		.HasMany(e => e.Portfolios)
		//		.WithOptional(e => e.Regulation)
		//		.HasForeignKey(e => e.RegulationId);

		//	modelBuilder.Entity<Regulation>()
		//		.HasMany(e => e.Rules)
		//		.WithRequired(e => e.Regulation)
		//		.WillCascadeOnDelete(false);

		//	modelBuilder.Entity<Stock>()
		//		.Property(e => e.Price)
		//		.HasPrecision(18, 0);

		//	modelBuilder.Entity<Stock>()
		//		.HasMany(e => e.Positions)
		//		.WithRequired(e => e.Stock)
		//		.WillCascadeOnDelete(false);
		//}
	}
}
