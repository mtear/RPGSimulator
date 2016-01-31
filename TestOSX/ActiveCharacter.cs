using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class ActiveCharacter : ActiveUnit
	{

		public ActiveCharacter (string name, StatContainer stats,
			List<Ability> skills, uint currenthp) : base (name,
				stats, skills, currenthp)
		{

		}

	}
}
