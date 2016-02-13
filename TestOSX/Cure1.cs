using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class Cure1 : Ability
	{
		public Cure1 () : base("Cure1", "", 3, 10, 0)
		{
		}

		public override uint UsageProbability(BattleField bf){ //TODO: I NEED TO CHANGE THIS
			foreach(ActiveCharacter c in bf.Allies){
				if (c.CurrentHP < (((double)c.Stats.HP) / 2))
					return 20;
			}
			return 0;
		}

		public override void UsageEffect_Inner(ActiveUnit user, ActiveUnit target){
			target.HealDamage (user, this);
		}

		public override uint Damage(ActiveUnit user){
			return (uint)(user.Stats.DEF*1.5 + user.Stats.LUK*.5);
		}

		public override ActiveUnit ChooseTarget (List<ActiveUnit> allies,
			List<ActiveUnit> enemies){
			for (int i = 0; i < allies.Count; i++) {
				ActiveUnit c = allies [i];
				if (c.CurrentHP < c.Stats.HP / 2)
					return allies[i];
			}
			return allies [0];
		}

	}
}

