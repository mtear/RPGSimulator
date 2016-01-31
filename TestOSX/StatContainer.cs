using System;

namespace TestOSX
{
	public class StatContainer
	{
		//Active stat values
		private uint level;
		public uint Level{
			get{
				return level;
			}
		}

		private uint hp, attack, defense, agility, accuracy, luck;
		public uint HP{
			get{
				return hp;
			}
		}
		public uint ATK {
			get {
				return attack;
			}
		}
		public uint DEF {
			get {
				return defense;
			}
		}
		public uint AGI {
			get {
				return agility;
			}
		}
		public uint ACC {
			get {
				return accuracy;
			}
		}
		public uint LUK {
			get {
				return luck;
			}
		}

		public StatContainer (uint level, uint hp, uint attack, uint defense,
			uint agility, uint accuracy, uint luck)
		{
			this.level = level;
			this.hp = hp;
			this.attack = attack;
			this.defense = defense;
			this.agility = agility;
			this.accuracy = accuracy;
			this.luck = luck;
		}

		public override string ToString ()
		{
			return string.Format ("Level: {0}\nHP: {1}\nATK: {2}\nDEF: {3}\nAGI: {4}\nACC: {5}\nLUK: {6}",
				Level, HP, ATK, DEF, AGI, ACC, LUK);
		}
	}
}

