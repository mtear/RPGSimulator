using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class ActiveUnit
	{

		private StatContainer stats;
		public StatContainer Stats {
			get {
				return stats;
			}
		}

		private uint currenthealth;
		public uint CurrentHP {
			get {
				return currenthealth;
			}
		}

		private string name;
		public string Name{
			get{
				return name;
			}
		}

		private List<Ability> skills;
		public List<Ability> Skills{
			get{
				return skills;
			}
		}

		public ActiveUnit (string name, StatContainer stats,
			List<Ability> skills, uint currenthp)
		{
			this.name = name;
			this.stats = stats;
			this.skills = skills;
			currenthealth = currenthp;
		}

		public void TakeDamage(ActiveUnit user, Ability ability){

			//Calculate damage
			uint damage = ability.Damage (user);
			if (stats.DEF/2 >= damage)
				damage = 1;
			else {
				damage -= stats.DEF/2;
				damage = ((uint)Math.Ceiling(((double)damage) * DamageModifier()));
			}

			double hitchance = HitChance (user, ability);

			bool HIT = Ability.R.NextDouble () <= hitchance;

			if (HIT) { //Attack hits

				double critchance = ((((double)user.stats.LUK) - ((double)stats.LUK))
					/ 100) + .03;
				if (critchance < .03)
					critchance = .03;
				else if (critchance > .25)
					critchance = .25;
				bool CRIT = Ability.R.NextDouble () <= critchance;

				if (CRIT) {
					Console.WriteLine ("%%%%% CRITICAL HIT! (" + critchance + ") %%%%%");
					Console.WriteLine ("%%%%% " + this.name +
						" TAKES " + damage + " DAMAGE (" + hitchance + ") %%%%%\n");

					damage = (uint)(((double)damage) * 2);
					
					if (damage > currenthealth) {
						currenthealth = 0;
					} else {
						currenthealth -= damage;
					}
				} else {
					Console.WriteLine ("%%%%% " + this.name +
						" TAKES " + damage + " DAMAGE (" + hitchance + ") %%%%%\n");

					if (damage > currenthealth) {
						currenthealth = 0;
					} else {
						currenthealth -= damage;
					}
				}
			} else { //Attack misses
				Console.WriteLine ("%%%%% ATTACK MISSED! (" + hitchance + ") %%%%%\n");
			}
		}

		private double HitChance(ActiveUnit user, Ability ability){
			double hitchance = 1;
			if(user.stats.ACC != 0){
				hitchance = (( ((double)user.stats.ACC) * 1.1 - ((double)stats.AGI)*.25)
					/ (double)user.stats.ACC) * ability.Accuracy;
			}
			//Cap hitchance at 95%
			if (hitchance > .95)
				hitchance = .95;
			else if (hitchance < .4)
				hitchance = .4;

			return hitchance;
		}

		public Ability SelectAbility(BattleField bf){
			return skills [0];
		}

		public virtual double DamageModifier (){ return 0;}

	}
}

