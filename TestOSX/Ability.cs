using System;
using System.Collections.Generic;

namespace TestOSX
{
	public abstract class Ability
	{
		private string name, iconname;

		public static Random R = new Random ();

		private double baseaccuracy;
		public double Accuracy{
			get{
				return baseaccuracy;
			}
		}

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

		private double critchance;
		public double CritChance {
			get {
				return critchance;
			}
		}

		private uint currentcooldown;
		public uint CurrentCooldown {
			get {
				return currentcooldown;
			}
		}

		public Ability (string name, string iconname, uint cooldown,
			double baseaccuracy, double critchance)
		{
			this.name = name;
			this.iconname = iconname;
			this.cooldown = cooldown;
			this.baseaccuracy = baseaccuracy;
			this.critchance = critchance;

			this.currentcooldown = 0;
		}

		public void LowerCooldown(){
			if(currentcooldown > 0) currentcooldown--;
		}

		public void UsageEffect(ActiveUnit user, ActiveUnit target){
			UsageEffect_Inner (user, target);
			currentcooldown = cooldown;
		}

		public abstract uint UsageProbability(BattleField bf);
		public abstract void UsageEffect_Inner(ActiveUnit user, ActiveUnit target);
		public abstract uint Damage(ActiveUnit user);
		public abstract ActiveUnit ChooseTarget (List<ActiveUnit> allies,
			List<ActiveUnit> enemies);
	}
}

