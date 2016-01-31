﻿using System;

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

		private uint hp, attack, defense, agility, intelligence, luck;
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
		public uint INT {
			get {
				return intelligence;
			}
		}
		public uint LUK {
			get {
				return luck;
			}
		}

		public StatContainer (uint level, uint hp, uint attack, uint defense,
			uint agility, uint intelligence, uint luck)
		{
			this.level = level;
			this.hp = hp;
			this.attack = attack;
			this.defense = defense;
			this.agility = agility;
			this.intelligence = intelligence;
			this.luck = luck;
		}

		public override string ToString ()
		{
			return string.Format ("Level: {0}\nHP: {1}\nATK: {2}\nDEF: {3}\nAGI: {4}\nINT: {5}\nLUK: {6}",
				Level, HP, ATK, DEF, AGI, INT, LUK);
		}
	}
}
