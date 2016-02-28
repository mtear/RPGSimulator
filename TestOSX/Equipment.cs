using System;

namespace TestOSX
{
	public abstract class Equipment : Item
	{

		private StatContainer stats;
		public StatContainer Stats {
			get {
				return stats;
			}
		}

		public Equipment (StatContainer stats)
		{
			this.stats = stats;
		}
	}
}

