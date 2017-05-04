using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalApp.Models;
using System.Collections.Generic;

namespace PersonalApp
{
	[TestClass]
	public class UnitTest
	{
		ItemsDataAccess dataAccess;

		[TestInitialize]
		public void initializ()
		{
			dataAccess = new ItemsDataAccess(true);
		}

		[TestMethod]
		public void GetWhenThereIsNoElement()
		{
			dataAccess = new ItemsDataAccess(true);
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(0, items.Count);
		}

		[TestMethod]
		public void GetWhenThereIsOneElement()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(new Item() { Strength = 1, Health = 2, Speed = 3, Defense = 4 });
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(1, items.Count);
		}

		[TestMethod]
		public void GetWhenThereMoreThanOneElement()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(new Item() { Strength = 1, Health = 2, Speed = 3, Defense = 4 });
			dataAccess.SaveItem(new Item() { Strength = 2, Health = 3, Speed = 4, Defense = 5 });
			dataAccess.SaveItem(new Item() { Strength = 3, Health = 4, Speed = 5, Defense = 6 });
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(6, items[2].Defense);
		}

		[TestMethod]
		public void GetOneElement()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(new Item() { Strength = 1, Health = 2, Speed = 3, Defense = 4 });
			dataAccess.SaveItem(new Item() { Strength = 2, Health = 3, Speed = 4, Defense = 5 });
			dataAccess.SaveItem(new Item() { Strength = 3, Health = 4, Speed = 5, Defense = 6 });
			Item items = dataAccess.GetItem(3);
			Assert.AreEqual(6, items.Defense);
		}

		[TestMethod]
		public void GetOneItemWhenThereIsNoElement()
		{
			dataAccess = new ItemsDataAccess(true);
			Item items = dataAccess.GetItem(3);
			Assert.IsNull(items);
		}

		[TestMethod]
		public void RemoveMoreThanOneElement()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(new Item() { Strength = 1, Health = 2, Speed = 3, Defense = 4 });
			dataAccess.SaveItem(new Item() { Strength = 2, Health = 3, Speed = 4, Defense = 5 });
			dataAccess.SaveItem(new Item() { Strength = 3, Health = 4, Speed = 5, Defense = 6 });

			dataAccess.DeleteItem(new Item() { Strength = 2, Health = 3, Speed = 4, Defense = 5 });
			dataAccess.DeleteItem(new Item() { Strength = 3, Health = 4, Speed = 5, Defense = 6 });
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(4, items[0].Defense);
		}

		[TestMethod]
		public void RemoveWhenThereIsNoElement()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.DeleteItem(new Item() { Strength = 3, Health = 4, Speed = 5, Defense = 6 });
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(0, items.Count);
		}


	}
}
