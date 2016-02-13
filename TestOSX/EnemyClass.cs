using System;
using System.Collections.Generic;

namespace TestOSX
{
	public abstract class EnemyClass : Class
	{

		public EnemyClass (double hp, double attack, double defense,
			double agility, double accuracy, double luck)
			: base(hp, attack, defense, agility, accuracy, luck)
		{
			
		}

		public abstract List<Ability> GetAbilities(uint level);

		private uint GetHP(uint level){
			return (uint)(this.hp * level);
		}

		private uint GetATK(uint level){
			return (uint)(this.attack * level);
		}

		private uint GetDEF(uint level){
			return (uint)(this.defense * level);
		}

		private uint GetAGI(uint level){
			return (uint)(this.agility * level);
		}

		private uint GetACC(uint level){
			return (uint)(this.accuracy * level);
		}

		private uint GetLUK(uint level){
			return (uint)(this.luck * level);
		}

		public StatContainer GetStats(uint level){
			return new StatContainer(level, GetHP(level),
				GetATK(level), GetDEF(level), GetAGI(level),
				GetACC(level), GetLUK(level));
		}

		public abstract List<Item> Drops (float droprate);

	}
}

