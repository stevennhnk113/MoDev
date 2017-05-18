using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalApp.Models;
using System.Collections.Generic;
using PersonalApp.ViewModels;
using PersonalApp.Views;
using System.Threading.Tasks;

namespace PersonalApp
{
	[TestClass]
	public class UnitTest
	{
		ItemsDataAccess dataAccess;
		ListViewModel testViewModel;
		UpdateItemPage testUpdateItemPage;
		AddItemPage testAddItemPage;
		ItemDetailPage testItemDetailPage;

		[TestInitialize]
		public void initializ()
		{
			dataAccess = new ItemsDataAccess(true);
		}

		[TestMethod]
		public void RunGetItem()
		{
			dataAccess.GetDataFromServer("1");
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
			dataAccess.SaveItem(new Item() { Strength = 1, Dexterity = 2, Speed = 3, Defense = 4 });
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(1, items.Count);
		}

		[TestMethod]
		public void GetWhenThereMoreThanOneElement()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(new Item() { Strength = 1, Dexterity = 2, Speed = 3, Defense = 4 });
			dataAccess.SaveItem(new Item() { Strength = 2, Dexterity = 3, Speed = 4, Defense = 5 });
			dataAccess.SaveItem(new Item() { Strength = 3, Dexterity = 4, Speed = 5, Defense = 6 });
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(6, items[2].Defense);
		}

		[TestMethod]
		public void GetOneElement()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(new Item() { Strength = 1, Dexterity = 2, Speed = 3, Defense = 4 });
			dataAccess.SaveItem(new Item() { Strength = 2, Dexterity = 3, Speed = 4, Defense = 5 });
			dataAccess.SaveItem(new Item() { Strength = 3, Dexterity = 4, Speed = 5, Defense = 6 });
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
			dataAccess.SaveItem(new Item() { Strength = 1, Dexterity = 2, Speed = 3, Defense = 4 });
			dataAccess.SaveItem(new Item() { Strength = 2, Dexterity = 3, Speed = 4, Defense = 5 });
			dataAccess.SaveItem(new Item() { Strength = 3, Dexterity = 4, Speed = 5, Defense = 6 });

			dataAccess.DeleteItem(new Item() { Strength = 2, Dexterity = 3, Speed = 4, Defense = 5 });
			dataAccess.DeleteItem(new Item() { Strength = 3, Dexterity = 4, Speed = 5, Defense = 6 });
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(4, items[0].Defense);
		}

		[TestMethod]
		public void RemoveWhenThereIsNoElement()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.DeleteItem(new Item() { Strength = 3, Dexterity = 4, Speed = 5, Defense = 6 });
			List<Item> items = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(0, items.Count);
		}

		//[TestMethod]
		//public void ListViewModelGetAllWhenThereIsNoItem()
		//{
		//	dataAccess = new ItemsDataAccess(true);

		//	testViewModel = new ListViewModel("List View", dataAccess);
		//	var task = testViewModel.ExecuteLoadItemsCommand();
		//	task.Wait();
		//	Assert.AreEqual(0, testViewModel.Items.Count);
		//}

		//[TestMethod]
		//public void ListViewModelGetAllWhenThereIsOneItem()
		//{
		//	dataAccess = new ItemsDataAccess(true);
		//	dataAccess.SaveItem(new Item() { Strength = 1, Dexterity = 2, Speed = 3, Defense = 4 });

		//	testViewModel = new ListViewModel("List View", dataAccess);
		//	var task = testViewModel.ExecuteLoadItemsCommand();
		//	task.Wait();
		//	Assert.AreEqual(2, testViewModel.Items[0].Health);
		//}

		//[TestMethod]
		//public void ListViewModelGetAllWhenThereAreMoreOneItem()
		//{
		//	dataAccess = new ItemsDataAccess(true);
		//	dataAccess.SaveItem(new Item() { Strength = 1, Dexterity = 2, Speed = 3, Defense = 4 });
		//	dataAccess.SaveItem(new Item() { Strength = 2, Dexterity = 3, Speed = 4, Defense = 5 });
		//	dataAccess.SaveItem(new Item() { Strength = 3, Dexterity = 4, Speed = 5, Defense = 6 });

		//	testViewModel = new ListViewModel("List View", dataAccess);
		//	var task = testViewModel.ExecuteLoadItemsCommand();
		//	task.Wait();
		//	Assert.AreEqual(6, testViewModel.Items[2].Defense);
		//}

		[TestMethod]
		public void ItemIsUpdatedWhenThereIsOnlyOneItem()
		{
			Item testItem = new Item() { Strength = 1, Dexterity = 2, Speed = 3, Defense = 4 };
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(testItem);
			testUpdateItemPage = new UpdateItemPage (testItem, dataAccess);
			testItem.Dexterity = 10;
			testItem.ItemNum = 1;
			testUpdateItemPage.TestUpdateItem_Clicked();
			List<Item> temp = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(10, temp[0].Dexterity);
		}

		//[TestMethod]
		//public void ItemIsUpdatedWhenThereAreMoreThanOneItem()
		//{
		//	Item testItem = new Item() { Strength = 1, Dexterity = 2, Speed = 3, Defense = 4};

		//	dataAccess = new ItemsDataAccess(true);
		//	dataAccess.SaveItem(testItem);
		//	dataAccess.SaveItem(new Item() { Strength = 2, Dexterity = 3, Speed = 4, Defense = 5});
		//	dataAccess.SaveItem(new Item() { Strength = 3, Dexterity = 4, Speed = 5, Defense = 6});

		//	testUpdateItemPage = new UpdateItemPage(testItem, dataAccess);
		//	testItem.Health = 10;
		//	testItem.ItemNum = 1;

		//	testUpdateItemPage.TestUpdateItem_Clicked();
		//	List<Item> temp = dataAccess.GetAllItem() as List<Item>;
		//	Assert.AreEqual(10, temp[0].Health);
		//}

		[TestMethod]
		public void ItemIsUpdatedWhenThereIsNoItem()
		{
			// Only update within Detail View, means there must be an item to view before updating
		}

		[TestMethod]
		public void AddItemWhenThereIsNoItem()
		{
			dataAccess = new ItemsDataAccess(true);
			testAddItemPage = new AddItemPage(dataAccess);

			testAddItemPage.Item.Speed = 5;

			testAddItemPage.TestSave_Clicked();

			List<Item> temp = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(5, temp[0].Speed);
		}

		[TestMethod]
		public void AddItemWhenThereAreItem()
		{
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(new Item() { Strength = 3, Dexterity = 4, Speed = 10, Defense = 6 });
			testAddItemPage = new AddItemPage(dataAccess);

			testAddItemPage.Item.Speed = 5;

			testAddItemPage.TestSave_Clicked();

			List<Item> temp = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(5, temp[1].Speed);
		}

		[TestMethod]
		public void DeleteWhenThereIsOneItem()
		{
			Item testItem = new Item() { Strength = 3, Dexterity = 4, Speed = 10, Defense = 6};
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(testItem);

			testItem.ItemNum = 1;

			testItemDetailPage = new ItemDetailPage(testItem, dataAccess);

			testItemDetailPage.TestDeleteItem_Clicked();

			List<Item> temp = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(0, temp.Count);
		}

		[TestMethod]
		public void DeleteWhenThereAreMoreThanOneItem()
		{
			Item testItem = new Item() { Strength = 3, Dexterity = 4, Speed = 10, Defense = 6 };
			dataAccess = new ItemsDataAccess(true);
			dataAccess.SaveItem(testItem);
			dataAccess.SaveItem(new Item() { Strength = 2, Dexterity = 3, Speed = 4, Defense = 5 });

			testItemDetailPage = new ItemDetailPage(testItem, dataAccess);

			testItem.ItemNum = 1;

			testItemDetailPage.TestDeleteItem_Clicked();

			List<Item> temp = dataAccess.GetAllItem() as List<Item>;
			Assert.AreEqual(3, temp[0].Dexterity);
		}


	}
}
