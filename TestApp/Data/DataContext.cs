namespace TestApp.Data
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class DataContext : DbContext
	{
		public DataContext()
			: base("name=DataContext")
		{
		}

		public virtual DbSet<Household> Households { get; set; }
		public virtual DbSet<Model> Models { get; set; }
		public virtual DbSet<Portfolio> Portfolios { get; set; }
		public virtual DbSet<Position> Positions { get; set; }
		public virtual DbSet<Regulation> Regulations { get; set; }
		public virtual DbSet<Rule> Rules { get; set; }
		public virtual DbSet<Stock> Stocks { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
