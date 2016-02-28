using System;

namespace TestOSX
{
	public class WoodShield : Equipment
	{
		public WoodShield () : base(new StatContainer (0, 0,
			0, 5, 0, 0, 0))
		{
		}

		public override string Name()
		{
			return "Wood Shield";
		}
	}
}

