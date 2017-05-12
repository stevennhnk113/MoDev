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

		int dexterity = 0;
		public int Dexterity
		{
			get { return dexterity; }
			set { SetProperty(ref dexterity, value); }
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
