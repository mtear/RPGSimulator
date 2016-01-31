using System;
using System.Collections.Generic;

namespace TestOSX
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<ActiveUnit> allies = new List<ActiveUnit> ();
			allies.Add (new Character ("Nic", "", 5,
				1, new uint[]{ 0 }, null, typeof(Drifter)).CreateActiveCharacter ());

			List<ActiveUnit> enemies = new List<ActiveUnit> ();
			enemies.Add (new Enemy ("Slime", typeof(Slime), 5).CreateActiveEnemy ());

			uint SIMULATIONS = 100, wins = 0;
			for (int i = 0; i < SIMULATIONS; i++) {
				BattleField bf = new BattleField (new List<ActiveUnit>(allies),
					new List<ActiveUnit>(enemies));
				bool win = bf.Simulate ();
				if (win)
					wins++;
			}
			double chance = (((double)wins) / ((double)SIMULATIONS)) * 100;
			Console.WriteLine ("\n\nWIN CHANCE: " + chance);
		}
			
	}
}
