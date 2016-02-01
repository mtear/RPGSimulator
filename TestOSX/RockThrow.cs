using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class RockThrow : Ability
	{
		public RockThrow () : base("Rock Throw", "", 1, 0.8, 0)
		{
		}

		public override uint UsageProbability(BattleField bf){
			return 5;
		}

		public override void UsageEffect_Inner(ActiveUnit user, ActiveUnit target){
			target.TakeDamage (user, this);
		}

		public override uint Damage(ActiveUnit user){
			return (uint)(user.Stats.ATK*1.7);
		}

		public override ActiveUnit ChooseTarget (List<ActiveUnit> allies,
			List<ActiveUnit> enemies){
			return enemies [new Random ().Next (enemies.Count)];
		}
	}
}
