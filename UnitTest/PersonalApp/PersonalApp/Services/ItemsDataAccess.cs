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
		bool testMode;

		public bool TestMode
		{
			get { return testMode; }
		}

		List<Item> testList;

		public ItemsDataAccess()
		{
			database =
			  DependencyService.Get<IDatabaseConnection>().
			  DbConnection();

			database.CreateTable<Item>();
			this.Items = new ObservableCollection<Item>(database.Table<Item>());
			testMode = false;
		}

		public ItemsDataAccess(bool testMode)
		{
			if (!testMode)
			{
				database =
			  DependencyService.Get<IDatabaseConnection>().
			  DbConnection();

				database.CreateTable<Item>();
				this.Items = new ObservableCollection<Item>(database.Table<Item>());
			}
			else
			{
				testList = new List<Item>();
			}

			this.testMode = testMode;
		}

		public IEnumerable<Item> GetAllItem()
		{
			// Use locks to avoid database collitions
			if (testMode)
			{
				List<Item> temp = new List<Item>();
				foreach (Item item in testList)
				{
					temp.Add(new Item()
					{
						ItemNum = item.ItemNum,
						ItemName = item.ItemName,
						Strength = item.Strength,
						Health = item.Health,
						Defense = item.Defense,
						Speed = item.Speed
					});
				}
				return temp;
			}
			else
			{
				lock (collisionLock)
				{
					var query = from item in database.Table<Item>()
								select item;
					return query.AsEnumerable();
				}
			}
		}

		public Item GetItem(int itemNum)
		{
			if (testMode)
			{
				foreach(Item item in testList)
				{
					if(item.ItemNum == itemNum)
					{
						return new Item()
						{
							Strength = item.Strength,
							Health = item.Health,
							Speed = item.Speed,
							Defense = item.Defense
						};
					}
				}
				return null;
			}

			lock (collisionLock)
			{
				return database.Table<Item>().FirstOrDefault(item => item.ItemNum == itemNum);
			}
		}

		public int SaveItem(Item inputItem)
		{
			if (testMode)
			{
				if (inputItem.ItemNum != 0)
				{
					foreach (Item item in testList)
					{
						if (inputItem.ItemNum == item.ItemNum)
						{
							item.ItemNum = inputItem.ItemNum;
							item.ItemName = inputItem.ItemName;
							item.Strength = inputItem.Strength;
							item.Health = inputItem.Health;
							item.Defense = inputItem.Defense;
							item.Speed = inputItem.Speed;
							return item.ItemNum;
						}
					}
				}
				else
				{
					int num;
					try
					{
						num = testList.Last().ItemNum + 1;
					}
					catch
					{
						num = 1;
					}
					inputItem.ItemNum = num;
					testList.Add(inputItem);
					return num;
				}
			}

			lock (collisionLock)
			{
				if (inputItem.ItemNum != 0)
				{
					database.Update(inputItem);
					return inputItem.ItemNum;
				}
				else
				{
					database.Insert(inputItem);
					return inputItem.ItemNum;
				}
			}
		}

		public int DeleteItem(Item item)
		{
			var id = item.ItemNum;
			if (testMode)
			{
				for (int index = 0; index < testList.Count; index++)
				{
					if (testList[index].ItemNum == id)
					{
						testList.RemoveAt(index);
					}
					return item.ItemNum;
				}
				return -1;
			}
			else
			{
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
}

//public void AddNewItem()
//{
//	this.Items.
//	  Add(new Item
//	  {
//		  ItemName = "Default name..."
//	  });
//}