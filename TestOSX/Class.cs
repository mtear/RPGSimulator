using System;

namespace TestOSX
{
	public class Class
	{
		//Growth factors
		protected double hp, attack, defense, agility, accuracy, luck;

		public Class (double hp, double attack, double defense,
			double agility, double accuracy, double luck)
		{
			this.hp = hp;
			this.attack = attack;
			this.defense = defense;
			this.agility = agility;
			this.accuracy = accuracy;
			this.luck = luck;
		}
	}
}

