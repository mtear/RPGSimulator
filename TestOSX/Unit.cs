using System;

namespace TestOSX
{
	public class Unit
	{

		protected uint level;

		protected Type type;

		protected string name;

		public Unit (string name, Type type)
		{
			this.name = name;
			this.type = type;
		}

	}
}

