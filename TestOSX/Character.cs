using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class Character : Unit
	{
		private uint breedmultiplier, exp;

		private string bodycode;

		private uint[] assignedskills;
		private uint[] skilllevels;

		public Character (string name, string bodycode, uint exp,
			uint breedmultiplier, uint[] assignedskills,
			uint[] skilllevels, Type type) : base(name, type)
		{
			this.bodycode = bodycode;
			this.exp = exp;
			this.breedmultiplier = breedmultiplier;
			this.assignedskills = assignedskills;
			this.skilllevels = skilllevels;

			PlayerClass c = (PlayerClass)Activator.CreateInstance (type);
			this.level = c.GetStats (breedmultiplier, exp).Level;
		}

		public ActiveCharacter CreateActiveCharacter(uint currenthp){
			PlayerClass c = (PlayerClass)Activator.CreateInstance (type);
			StatContainer stats = c.GetStats(breedmultiplier, exp);

			List<Ability> allabilities = c.GetAbilities (exp);
			List<Ability> abilities = new List<Ability>();
			foreach (uint i in assignedskills) {
				//Avoid out of bounds errors
				try{
					abilities.Add(allabilities[(int)i]);
				}catch{
				}
			}

			return new ActiveCharacter (name, stats, abilities, currenthp);
		}

		public ActiveCharacter CreateActiveCharacter(){
			PlayerClass c = (PlayerClass)Activator.CreateInstance (type);
			StatContainer stats = c.GetStats(breedmultiplier, exp);
			return CreateActiveCharacter (stats.HP);
		}
			
	}
}

