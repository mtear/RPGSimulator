using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class ActiveEnemy : ActiveUnit
	{
		private EnemyClass enemyType;

		public ActiveEnemy (string name, StatContainer stats,
			List<Ability> skills, uint currenthp, 
			EnemyClass enemyType) : base (name, stats, skills, currenthp)
		{
			this.enemyType = enemyType;
		}

		public override double DamageModifier(){
			double roll = ((double)Ability.R.Next (20)) * .1;
			return .8 + roll;
		}

		public override List<Item> GetSpoils(float droprate){
			return enemyType.Drops (droprate);
		}

	}
}

