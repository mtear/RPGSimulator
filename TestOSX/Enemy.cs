using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class Enemy : Unit
	{
		public Enemy (string name, Type type, uint level) : base(name, type)
		{
			this.level = level;
		}

		public ActiveEnemy CreateActiveEnemy(uint currenthp){
			EnemyClass c = (EnemyClass)Activator.CreateInstance (type);
			StatContainer stats = c.GetStats(this.level);

			List<Ability> abilities = c.GetAbilities (this.level);

			return new ActiveEnemy (name, stats, abilities, currenthp, c);
		}

		public ActiveEnemy CreateActiveEnemy(){
			EnemyClass c = (EnemyClass)Activator.CreateInstance (type);
			StatContainer stats = c.GetStats(this.level);
			return CreateActiveEnemy (stats.HP);
		}

	}
}

