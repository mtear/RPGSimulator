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

		public override double DamageModifier(){
			double roll = ((double)Ability.R.Next (20)) * .1;
			return .4 + roll;
		}

	}
}
