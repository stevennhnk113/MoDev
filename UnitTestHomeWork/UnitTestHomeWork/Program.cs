using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestHomeWork
{
	public class Program
	{
		public bool ToHit(int level, int str, int def)
		{

			if (level < 0) return false;

			if (str < 0) return false;

			if (def < 0) return false;

			if (str > 0 && def < 1) return true;

			if (str + level > def) return true;

			return false;

		}

		static void Main(string[] args)
		{
		}
	}
}
