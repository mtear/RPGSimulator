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

		public void TakeDamage(uint damage){
			Console.WriteLine ("%%%%% " + this.name +
				" TAKES " + damage + " DAMAGE %%%%%\n");
			
			if (damage > currenthealth) {
				currenthealth = 0;
			} else {
				currenthealth -= damage;
			}
		}

		public Ability SelectAbility(BattleField bf){
			return skills [0];
		}

	}
}

