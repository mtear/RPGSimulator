using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class Slime : EnemyClass
	{
		public Slime () : base(10,1,1,1,0,0)
		{
		}

		public override List<Ability> GetAbilities(uint exp){
			List<Ability> ret = new List<Ability>();
			ret.Add(new BasicAttack());
			return ret;
		}
	}
}

