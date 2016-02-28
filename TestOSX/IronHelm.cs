using System;

namespace TestOSX
{
	public class IronHelm : Equipment
	{
		public IronHelm () : base(new StatContainer (0, 0,
			0, 10, 0, 0, 0))
		{
			
		}

		public override string Name ()
		{
			return "Iron Helm";
		}
	}
}

