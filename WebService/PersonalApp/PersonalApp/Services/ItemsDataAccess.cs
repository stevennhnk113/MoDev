using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using PersonalApp.Models;
using PersonalApp.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

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

			if (!database.Table<Item>().Any())
			{

			}
		}

		public void GetDataFromServer()
		{
			List<Item> tempList = new List<Item>();

			
			for(int i = 0; i <= 3; i++)
			{
				JObject itemJobject = JObject.Parse(GetJsonString(i.ToString()));
				Item tempItem = null;
				if (itemJobject.First.First.Value<int>() == 0)
				{
					foreach (var each in itemJobject.Last.First)
					{
						tempItem = new Item();
						tempItem.ItemName = each["Name"].Value<String>();
						switch (each["Attribute"].Value<String>())
						{
							case "Dex":
								tempItem.Dexterity = each["Value"].Value<int>();
								break;
							case "Str":
								tempItem.Strength = each["Value"].Value<int>();
								break;
							case "Spd":
								tempItem.Speed = each["Value"].Value<int>();
								break;
							case "Def":
								tempItem.Defense = each["Value"].Value<int>();
								break;
						}
						SaveItem(tempItem);
					}
				}
			}
		}

		public List<Item> GetDataFromServer(string num)
		{
			List<Item> tempList = new List<Item>();
			JObject itemJobject = JObject.Parse(GetJsonString(num));
			Item tempItem = null;
			if (itemJobject.First.First.Value<int>() == 0)
			{
				foreach (var each in itemJobject.Last.First)
				{
					tempItem = new Item();
					tempItem.ItemName = each["Name"].Value<String>();
					switch (each["Attribute"].Value<String>())
					{
						case "Dex":
							tempItem.Dexterity = each["Value"].Value<int>();
							break;
						case "Str":
							tempItem.Strength = each["Value"].Value<int>();
							break;
						case "Spd":
							tempItem.Speed = each["Value"].Value<int>();
							break;
						case "Def":
							tempItem.Defense = each["Value"].Value<int>();
							break;
					}
					tempList.Add(tempItem);
				}
			}
			return tempList;
		}

		private string GetJsonString(string num)
		{
			HttpClient request = new HttpClient();
			request.BaseAddress = new Uri("http://thursdayhomework.azurewebsites.net");
			request.DefaultRequestHeaders.Accept.Clear();
			request.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

			Task<HttpResponseMessage> task = request.GetAsync("/API/GetItemList/" + num);
			task.Wait();
			return task.Result.Content.ReadAsStringAsync().Result;
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
						Dexterity = item.Dexterity,
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
							Dexterity = item.Dexterity,
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
							item.Dexterity = inputItem.Dexterity;
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