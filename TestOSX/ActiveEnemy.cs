using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class ActiveEnemy : ActiveUnit
	{
		public ActiveEnemy (string name, StatContainer stats,
			List<Ability> skills, uint currenthp) : base (name,
				stats, skills, currenthp)
		{

		}
	}
}

