namespace TestApp
{
	using System.Linq;
	using Data;

	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new DataContext())
			{
				var portfolios = db.Portfolios.ToArray();
			}
		}
	}
}
