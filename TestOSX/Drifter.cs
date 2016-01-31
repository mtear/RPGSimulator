using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class Drifter : PlayerClass
	{
		public Drifter () : base(3, 1, 1, 1, 1, 1)
		{
		}

		protected override uint GetLevel(uint exp){
			return exp;
		}

		protected override uint GetMaxLevel (uint mult){
			return 10;
		}

		public override List<Ability> GetAbilities(uint exp){
			List<Ability> ret = new List<Ability>();
			ret.Add(new BasicAttack());
			return ret;
		}
	}
}

