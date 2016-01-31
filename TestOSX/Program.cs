using System;
using System.Collections.Generic;

namespace TestOSX
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<ActiveUnit> allies = new List<ActiveUnit> ();
			allies.Add (new Character ("Nic", "", 10,
				1, new uint[]{ 0 }, null, typeof(Drifter)).CreateActiveCharacter ());

			List<ActiveUnit> enemies = new List<ActiveUnit> ();
			enemies.Add (new Enemy ("Slime", typeof(Slime), 5).CreateActiveEnemy ());

			BattleField bf = new BattleField (allies, enemies);
			bf.Simulate ();
		}
			
	}
}
