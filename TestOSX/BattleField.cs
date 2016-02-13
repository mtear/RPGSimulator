using System;
using System.Collections.Generic;

namespace TestOSX
{
	public class BattleField
	{
		public List<ActiveUnit> Allies;
		public List<ActiveUnit> Enemies;

		private List<Item> Spoils;

		public BattleField (List<ActiveUnit> allies,
			List<ActiveUnit> enemies)
		{
			this.Allies = allies;
			this.Enemies = enemies;

			Spoils = new List<Item> ();
		}

		public void PrintState(){
			Utility.WriteLine ("");
			Utility.WriteLine ("************************");

			Utility.WriteLine ("****** ALLIES ******");
			foreach (ActiveUnit a in Allies) {
				Utility.WriteLine ("");
				Utility.WriteLine (a.Name);
				Utility.WriteLine ("Current HP: " + a.CurrentHP);
				Utility.WriteLine (a.Stats.ToString());
			}
			Utility.WriteLine ("");
			Utility.WriteLine ("****** ENEMIES ******");
			foreach (ActiveUnit e in Enemies) {
				Utility.WriteLine ("");
				Utility.WriteLine (e.Name);
				Utility.WriteLine ("Current HP: " + e.CurrentHP);
				Utility.WriteLine (e.Stats.ToString());
			}

			Utility.WriteLine ("");
			Utility.WriteLine ("************************");
		}

		public bool Simulate(){

			for (int i = 0; i < 30; i++) {
				Utility.WriteLine ("\n### ROUND " + (i+1) + " ###\n");
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
			Utility.WriteLine ("\n%%%%% " + user.Name + " USES "
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
					Spoils.AddRange (Enemies [i].GetSpoils (1f));
					Enemies.RemoveAt (i);
					i--;
				}
			}
		}

		public uint CheckIfEnded(){
			if (Enemies.Count == 0) {
				Utility.WriteLine ("^^^^^ BATTLE OVER ^^^^^^");
				foreach (Item i in Spoils) {
					Utility.WriteLine ("&&&&& GOT A " + i.Name () + " &&&&&");
				}
				Utility.WriteLine ("\n^^^^^ ALLIES WIN ^^^^^^");
				return 1;
			}
			if (Allies.Count == 0) {
				Utility.WriteLine ("^^^^^ BATTLE OVER ^^^^^^");
				Utility.WriteLine ("^^^^^ ENEMIES WIN ^^^^^^");
				return 2;
			}
			return 0;
		}

		public List<Item> GetSpoils(){
			return Spoils;
		}
	}
}

