namespace PersonalApp.Services
{
	public interface IDatabaseConnection
	{
		SQLite.SQLiteConnection DbConnection();
	}
}
