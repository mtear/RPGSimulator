using System;
using System.Collections.Generic;

namespace TestOSX
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			uint SIMULATIONS = 10000, wins = 0;
			for (int i = 0; i < SIMULATIONS; i++) {

				List<ActiveUnit> allies = new List<ActiveUnit> ();
				allies.Add (new Character ("Nic", "", 5,
					1, new uint[]{ 0, 1, 2 }, null, typeof(Drifter)).CreateActiveCharacter ());

				List<ActiveUnit> enemies = new List<ActiveUnit> ();
				Enemy e = new Enemy ("Slime", typeof(Slime), 4);
				enemies.Add (e.CreateActiveEnemy ());
				enemies.Add (e.CreateActiveEnemy ());
				enemies.Add (e.CreateActiveEnemy ());
				enemies.Add (e.CreateActiveEnemy ());
				enemies.Add (e.CreateActiveEnemy ());

				BattleField bf = new BattleField (allies, enemies);
				bool win = bf.Simulate ();
				if (win) {
					wins++;
				}
			}
			double chance = (((double)wins) / ((double)SIMULATIONS)) * 100;
			Console.WriteLine ("\n\nWIN CHANCE: " + chance);
		}
			
	}
}
