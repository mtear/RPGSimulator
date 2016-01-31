using System;
using System.Collections.Generic;

namespace TestOSX
{
	public abstract class EnemyClass : Class
	{

		public EnemyClass (double hp, double attack, double defense,
			double agility, double intelligence, double luck)
			: base(hp, attack, defense, agility, intelligence, luck)
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

		private uint GetINT(uint level){
			return (uint)(this.intelligence * level);
		}

		private uint GetLUK(uint level){
			return (uint)(this.luck * level);
		}

		public StatContainer GetStats(uint level){
			return new StatContainer(level, GetHP(level),
				GetATK(level), GetDEF(level), GetAGI(level),
				GetINT(level), GetLUK(level));
		}

	}
}

