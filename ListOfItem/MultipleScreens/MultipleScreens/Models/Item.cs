﻿namespace MultipleScreens.Models
{
    public class Item : BaseDataObject
	{
		string itemName = string.Empty;
		public string ItemName
		{
			get { return itemName; }
			set { SetProperty(ref itemName, value); }
		}

		string strength = string.Empty;
		public string Strength
		{
			get { return strength; }
			set { SetProperty(ref strength, value); }
		}

		string health = string.Empty;
		public string Health
		{
			get { return health; }
			set { SetProperty(ref health, value); }
		}

		string defense = string.Empty;
		public string Defense
		{
			get { return defense; }
			set { SetProperty(ref defense, value); }
		}

		string speed = string.Empty;
		public string Speed
		{
			get { return speed; }
			set { SetProperty(ref speed, value); }
		}
	}
}
