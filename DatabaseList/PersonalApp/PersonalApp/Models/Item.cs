//using SQLite;
//using System.ComponentModel;

//namespace PersonalApp.Models
//{

//	[Table("Items")
//	public class Item : BaseDataObject
//	{
//		string itemName = string.Empty;
//		public string ItemName
//		{
//			get { return itemName; }
//			set { SetProperty(ref itemName, value); }
//		}

//		string strength = string.Empty;
//		public string Strength
//		{
//			get { return strength; }
//			set { SetProperty(ref strength, value); }
//		}

//		string health = string.Empty;
//		public string Health
//		{
//			get { return health; }
//			set { SetProperty(ref health, value); }
//		}

//		string defense = string.Empty;
//		public string Defense
//		{
//			get { return defense; }
//			set { SetProperty(ref defense, value); }
//		}

//		string speed = string.Empty;
//		public string Speed
//		{
//			get { return speed; }
//			set { SetProperty(ref speed, value); }
//		}
//	}
//}

using SQLite;
using System.ComponentModel;

namespace PersonalApp.Models
{

	[Table("Items")]
	public class Item : BaseDataObject
	{
		int itemNum;
		[PrimaryKey, AutoIncrement]
		public int ItemNum
		{
			get { return itemNum; }
			set { SetProperty(ref itemNum, value); }
		}

		string itemName = string.Empty;
		[NotNull]
		public string ItemName
		{
			get { return itemName; }
			set { SetProperty(ref itemName, value); }
		}

		int strength = 0;
		public int Strength
		{
			get { return strength; }
			set { SetProperty(ref strength, value); }
		}

		int health = 0;
		public int Health
		{
			get { return health; }
			set { SetProperty(ref health, value); }
		}

		int defense = 0;
		public int Defense
		{
			get { return defense; }
			set { SetProperty(ref defense, value); }
		}

		int speed = 0;
		public int Speed
		{
			get { return speed; }
			set { SetProperty(ref speed, value); }
		}
	}
}
