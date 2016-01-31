using System;
using System.Collections.Generic;

namespace TestOSX
{
	public abstract class Ability
	{
		private string name, iconname;
		public string Name {
			get {
				return name;
			}
		}
		public string Icon {
			get {
				return iconname;
			}
		}

		private uint cooldown;
		public uint Cooldown {
			get {
				return cooldown;
			}
		}

		public Ability (string name, string iconname, uint cooldown)
		{
			this.name = name;
			this.iconname = iconname;
			this.cooldown = cooldown;
		}

		public abstract uint UsageProbability(BattleField bf);
		public abstract void UsageEffect(ActiveUnit user, ActiveUnit target);
		public abstract uint Damage(StatContainer st);
		public abstract ActiveUnit ChooseTarget (List<ActiveUnit> allies,
			List<ActiveUnit> enemies);
	}
}

