using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class Slime : EnemyClass
	{
		public Slime () : base(2,.8,.8,.9,.8,.5)
		{
		}

		public override List<Ability> GetAbilities(uint exp){
			List<Ability> ret = new List<Ability>();
			ret.Add(new BasicAttack());
			return ret;
		}

		public override List<Item> Drops (float droprate){
			List<Item> ret = new List<Item> ();
			if (Ability.R.Next (10) < 5)
				ret.Add (new WoodShield ());
			if (Ability.R.Next (10) == 0)
				ret.Add (new IronHelm ());

			return ret;
		}

	}
}

