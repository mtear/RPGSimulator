using System;

namespace TestOSX
{
	public class EquipmentSet
	{

		private Equipment[] itemslots;

		public Equipment HEAD{
			get{
				return itemslots [0];
			}
		}

		public Equipment CHEST{
			get{
				return itemslots [1];
			}
		}

		public Equipment PANTS{
			get{
				return itemslots [2];
			}
		}

		public Equipment BOOTS{
			get{
				return itemslots [3];
			}
		}

		public Equipment WEAPON{
			get{
				return itemslots [4];
			}
		}

		public Equipment OFFHAND{
			get{
				return itemslots [5];
			}
		}

		public Equipment ACC1{
			get{
				return itemslots [6];
			}
		}

		public StatContainer CombinedStats {
			get {
				StatContainer st = new StatContainer (0, 0, 0, 0, 0, 0, 0);
				foreach (Equipment s in itemslots) {
					st += s.Stats;
				}
				return st;
			}
		}

		public Equipment ACC2{
			get{
				return itemslots [7];
			}
		}

		public EquipmentSet (Equipment HEAD, Equipment CHEST, Equipment PANTS, Equipment BOOTS,
			Equipment WEAPON, Equipment OFFHAND, Equipment ACC1, Equipment ACC2)
		{
			itemslots = new Equipment[8];
			itemslots [0] = HEAD;
			itemslots [1] = CHEST;
			itemslots [2] = PANTS;
			itemslots [3] = BOOTS;
			itemslots [4] = WEAPON;
			itemslots [5] = OFFHAND;
			itemslots [6] = ACC1;
			itemslots [7] = ACC2;
			CheckEmpties ();
		}

		public EquipmentSet(){
			itemslots = new Equipment[8];
			CheckEmpties ();
		}

		private void CheckEmpties(){
			for (int i = 0; i < 8; i++) {
				if (itemslots [i] == null)
					itemslots [i] = new EmptyEquipment ();
			}
		}
	}
}

