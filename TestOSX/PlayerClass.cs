﻿using System;
using System.Collections.Generic;

namespace TestOSX
{
	public abstract class PlayerClass : Class
	{
		
		public PlayerClass (double hp, double attack, double defense,
			double agility, double accuracy, double luck)
			: base(hp, attack, defense, agility, accuracy, luck)
		{
		}

		protected abstract uint GetLevel(uint exp);
		protected abstract uint GetMaxLevel (uint mult);

		public abstract List<Ability> GetAbilities(uint exp);

		private uint GetHP(uint mult, uint exp){
			return (uint)(this.hp * GetLevel(exp));
		}

		private uint GetATK(uint mult, uint exp){
			return (uint)(this.attack * GetLevel(exp));
		}

		private uint GetDEF(uint mult, uint exp){
			return (uint)(this.defense * GetLevel(exp));
		}

		private uint GetAGI(uint mult, uint exp){
			return (uint)(this.agility * GetLevel(exp));
		}

		private uint GetACC(uint mult, uint exp){
			return (uint)(this.accuracy * GetLevel(exp));
		}

		private uint GetLUK(uint mult, uint exp){
			return (uint)(this.luck * GetLevel(exp));
		}

		public StatContainer GetStats(uint mult, uint exp){
			return new StatContainer(GetLevel(exp), GetHP(mult, exp),
				GetATK(mult,exp), GetDEF(mult,exp), GetAGI(mult,exp),
				GetACC(mult, exp), GetLUK(mult,exp));
		}

	}
}

