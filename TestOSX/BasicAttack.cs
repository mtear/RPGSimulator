using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class BasicAttack : Ability
	{
		public BasicAttack () : base("Attack", "", 0)
		{
		}

		public override uint UsageProbability(BattleField bf){
			return 1;
		}

		public override void UsageEffect(ActiveUnit user, ActiveUnit target){
			target.TakeDamage (Damage(user.Stats));
		}

		public override uint Damage(StatContainer st){
			return st.ATK;
		}

		public override ActiveUnit ChooseTarget (List<ActiveUnit> allies,
			List<ActiveUnit> enemies){
			return enemies [new Random ().Next (enemies.Count)];
		}
	}
}

