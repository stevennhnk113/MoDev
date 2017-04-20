using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using PersonalApp.Models;
using PersonalApp.Services;
using System;

namespace PersonalApp
{
	public class ItemsDataAccess
	{
		private SQLiteConnection database;
		private static object collisionLock = new object();
		public ObservableCollection<Item> Items { get; set; }
		public ItemsDataAccess()
		{
			database =
			  DependencyService.Get<IDatabaseConnection>().
			  DbConnection();
			try
			{
				database.CreateTable<Item>();
			}
			catch
			{
				
			}
			this.Items =
			  new ObservableCollection<Item>(database.Table<Item>());
			// If the table is empty, initialize the collection
			if (!database.Table<Item>().Any())
			{
				AddNewItem();
			}
		}
		public void AddNewItem()
		{
			this.Items.
			  Add(new Item
			  {
				  ItemName = "Default name..."
			  });
		}
		// Use LINQ to query and filter data
		public IEnumerable<Item> GetFilteredItems(int id)
		{
			// Use locks to avoid database collitions
			lock (collisionLock)
			{
				var query = from cust in database.Table<Item>()
							where cust.ID == id
							select cust;
				return query.AsEnumerable();
			}
		}

		public Item GetItem(int id)
		{
			lock (collisionLock)
			{
				return database.Table<Item>().
				  FirstOrDefault(item => item.ID == id);
			}
		}
		public int SaveItem(Item item)
		{
			lock (collisionLock)
			{
				if (item.ID != 0)
				{
					database.Update(item);
					return item.ID;
				}
				else
				{
					database.Insert(item);
					return item.ID;
				}
			}
		}

		public int DeleteCustomer(Item item)
		{
			var id = item.ID;
			if (id != 0)
			{
				lock (collisionLock)
				{
					database.Delete<Item>(id);
				}
			}
			this.Items.Remove(item);
			return id;
		}
	}
}