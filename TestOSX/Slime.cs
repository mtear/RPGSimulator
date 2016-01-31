using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class Slime : EnemyClass
	{
		public Slime () : base(2.2,.8,.8,1,.8,0)
		{
		}

		public override List<Ability> GetAbilities(uint exp){
			List<Ability> ret = new List<Ability>();
			ret.Add(new BasicAttack());
			return ret;
		}
	}
}

