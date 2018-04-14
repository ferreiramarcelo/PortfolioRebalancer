namespace PortfolioRebalancer.Data
{
	using System.Data.Entity;

	public class AppDataContext : DbContext
	{
		public AppDataContext()
			: base("name=AppDataContext")
		{
			//this.Configuration.LazyLoadingEnabled = false;
		}

		public virtual DbSet<Household> Households { get; set; }

		public virtual DbSet<Model> Models { get; set; }

		public virtual DbSet<Portfolio> Portfolios { get; set; }

		public virtual DbSet<Position> Positions { get; set; }

		public virtual DbSet<Regulation> Regulations { get; set; }

		public virtual DbSet<Rule> Rules { get; set; }

		public virtual DbSet<Security> Securities { get; set; }
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
