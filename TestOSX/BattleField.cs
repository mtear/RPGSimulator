using System;
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

		public void Simulate(){

			for (int i = 0; i < 30; i++) {
				Console.WriteLine ("\n### ROUND " + (i+1) + " ###\n");
				PrintState ();

				foreach (ActiveUnit a in Allies) {
					Ability ability = a.SelectAbility (this);
					uint weight = ability.UsageProbability (this);
					if (weight == 1) {
						ActiveUnit target = ability.ChooseTarget
							(Allies, Enemies);
						ExecuteAbility (ability, a, target);

						RemoveCorpses ();
						CheckIfEnded ();
					}
				}
				foreach (ActiveUnit e in Enemies) {
					Ability ability = e.SelectAbility (this);
					uint weight = ability.UsageProbability (this);
					if (weight == 1) {
						ActiveUnit target = ability.ChooseTarget 
							(Enemies, Allies);
						ExecuteAbility (ability, e, target);

						RemoveCorpses ();
						CheckIfEnded ();
					}
				}

				Console.Read ();
			}
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

		public void CheckIfEnded(){
			if (Enemies.Count == 0) {
				Console.WriteLine ("^^^^^ BATTLE OVER ^^^^^^");
				Console.WriteLine ("^^^^^ ALLIES WIN ^^^^^^");
				Environment.Exit (0);
			}
			if (Allies.Count == 0) {
				Console.WriteLine ("^^^^^ BATTLE OVER ^^^^^^");
				Console.WriteLine ("^^^^^ ENEMIES WIN ^^^^^^");
				Environment.Exit (0);
			}
		}
	}
}

