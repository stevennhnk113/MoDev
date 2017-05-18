using SQLite;
using LocalDataAccess.Droid;
using System.IO;
using PersonalApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace LocalDataAccess.Droid
{
	public class DatabaseConnection_Android : IDatabaseConnection
	{
		public SQLiteConnection DbConnection()
		{
			var dbName = "GameDB.db3";
			var path = Path.Combine(System.Environment.
			  GetFolderPath(System.Environment.
			  SpecialFolder.Personal), dbName);

			var temp = new SQLiteConnection(path);
			return temp;
		}
	}
}