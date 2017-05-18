namespace PersonalApp.Models
{
	public class Character : BaseDataObject
	{
		int randomNum;
		public int RandomNum
		{
			get { return randomNum; }
			set { SetProperty(ref randomNum, value); }
		}

		string type = string.Empty;
		public string Type
		{
			get { return type; }
			set { SetProperty(ref type, value); }
		}

		int level = 0;
		public int Level
		{
			get { return level; }
			set { SetProperty(ref level, value); }
		}
	}
}
