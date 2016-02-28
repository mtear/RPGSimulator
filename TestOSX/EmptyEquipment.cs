using System;

namespace TestOSX
{
	public class EmptyEquipment : Equipment
	{
		public EmptyEquipment () : base(new StatContainer(0,0,0,0,0,0,0))
		{
		}

		public override string Name()
		{
			return "Empty";
		}
	}
}

