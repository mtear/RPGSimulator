using System;

namespace TestOSX
{
	public class Class
	{
		//Growth factors
		protected double hp, attack, defense, agility, intelligence, luck;

		public Class (double hp, double attack, double defense,
			double agility, double intelligence, double luck)
		{
			this.hp = hp;
			this.attack = attack;
			this.defense = defense;
			this.agility = agility;
			this.intelligence = intelligence;
			this.luck = luck;
		}
	}
}

