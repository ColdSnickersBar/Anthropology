using System;

namespace Game
{
	public class Settlement
	{
		public float PopulationProgress {
			get;
			private set;
		}

		public int Population {
			get;
			private set;
		}

		public Settlement ()
		{
		}

		public void Turn ()
		{
			IncreasePopulationProgress ();
		}

		void IncreasePopulationProgress ()
		{
			PopulationProgress += 0.1f;
			if (PopulationProgress >= 1f) {
				PopulationProgress -= 1f;
				Population++;
			}
		}
	}
}

