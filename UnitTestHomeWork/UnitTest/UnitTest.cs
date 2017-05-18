using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestHomeWork;

namespace UnitTest
{
	[TestClass]
	public class UnitTest
	{
		Program tester;

		[TestInitialize]
		public void Initializer()
		{
			tester = new Program();
		}

		[TestMethod]
		public void LevelIsLessThanZero()
		{
			Assert.IsFalse(tester.ToHit(-1, 1, 1));
		}

		[TestMethod]
		public void StrengthIsLessThanZero()
		{
			Assert.IsFalse(tester.ToHit(1, -1, 1));
		}

		[TestMethod]
		public void DefenseIsLessThanZero()
		{
			Assert.IsFalse(tester.ToHit(1, 1, -1));
		}

		[TestMethod]
		public void StrengthIsMoreThanZeroAndDefenseIsLessThanOne()
		{
			Assert.IsTrue(tester.ToHit(1, 1, 0));
		}

		[TestMethod]
		public void StrengthIsMoreThanZeroAndDefenseIsOne()
		{
			Assert.IsFalse(tester.ToHit(0, 1, 1));
		}

		[TestMethod]
		public void StrengthIsZeroAndStrengthPlusLevelIsMoreThanDefense()
		{
			Assert.IsTrue(tester.ToHit(4, 0, 2));
		}

		[TestMethod]
		public void StrengthIsZeroAndStrengthPlusLevelIsLessThanDefense()
		{
			Assert.IsFalse(tester.ToHit(4, 0, 5));
		}
	}
}
