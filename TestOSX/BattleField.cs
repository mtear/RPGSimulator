﻿using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class BattleField
	{
		public List<ActiveUnit> Allies;
		public List<ActiveUnit> Enemies;

		public BattleField (List<ActiveUnit> allies,
			List<ActiveUnit> enemies)
		{
			this.Allies = allies;
			this.Enemies = enemies;
		}

		public void PrintState(){
			Console.WriteLine ("");
			Console.WriteLine ("************************");

			Console.WriteLine ("****** ALLIES ******");
			foreach (ActiveUnit a in Allies) {
				Console.WriteLine ("");
				Console.WriteLine (a.Name);
				Console.WriteLine ("Current HP: " + a.CurrentHP);
				Console.WriteLine (a.Stats.ToString());
			}
			Console.WriteLine ("");
			Console.WriteLine ("****** ENEMIES ******");
			foreach (ActiveUnit e in Enemies) {
				Console.WriteLine ("");
				Console.WriteLine (e.Name);
				Console.WriteLine ("Current HP: " + e.CurrentHP);
				Console.WriteLine (e.Stats.ToString());
			}

			Console.WriteLine ("");
			Console.WriteLine ("************************");
		}

		public bool Simulate(){

			for (int i = 0; i < 30; i++) {
				Console.WriteLine ("\n### ROUND " + (i+1) + " ###\n");
				PrintState ();

				List<ActiveUnit> allunits = new List<ActiveUnit> ();
				foreach (ActiveUnit a in Allies)
					allunits.Add (a);
				foreach (ActiveUnit e in Enemies)
					allunits.Add (e);

				//Sort by AGI
				allunits.Sort((x, y) => string.Compare(y.Stats.AGI.ToString(),
					x.Stats.AGI.ToString()));

				foreach (ActiveUnit a in allunits) {

					if (a.CurrentHP == 0)
						continue;

					Ability ability = a.SelectAbility (this);
					ActiveUnit target;
					if(a.GetType() == typeof(ActiveCharacter))
						target = ability.ChooseTarget (Allies, Enemies);
					else
						target = ability.ChooseTarget (Enemies, Allies);
					ExecuteAbility (ability, a, target);

					//lower cooldowns
					foreach (Ability s in a.Skills) {
						if(s != ability)
							s.LowerCooldown ();
					}

					RemoveCorpses ();
					uint code = CheckIfEnded ();
					if (code > 0)
						return (code == 1);
				}

				//Console.Read ();
			}

			return false;
		}

		public void ExecuteAbility(Ability ability,
			ActiveUnit user, ActiveUnit target){
			Console.WriteLine ("\n%%%%% " + user.Name + " USES "
				+ ability.Name + " ON " + target.Name + " %%%%%\n");
			ability.UsageEffect (user, target);
		}

		public void RemoveCorpses(){
			for (int i = 0; i < Allies.Count; i++) {
				if (Allies [i].CurrentHP == 0) {
					Allies.RemoveAt (i);
					i--;
				}
			}
			for (int i = 0; i < Enemies.Count; i++) {
				if (Enemies [i].CurrentHP == 0) {
					Enemies.RemoveAt (i);
					i--;
				}
			}
		}

		public uint CheckIfEnded(){
			if (Enemies.Count == 0) {
				Console.WriteLine ("^^^^^ BATTLE OVER ^^^^^^");
				Console.WriteLine ("^^^^^ ALLIES WIN ^^^^^^");
				return 1;
			}
			if (Allies.Count == 0) {
				Console.WriteLine ("^^^^^ BATTLE OVER ^^^^^^");
				Console.WriteLine ("^^^^^ ENEMIES WIN ^^^^^^");
				return 2;
			}
			return 0;
		}
	}
}

