using NUnit.Framework;
using System;
using Game;

namespace Tests
{
	[TestFixture ()]
	public class TestSettlement
	{
		Settlement m_settlement;

		[SetUp]
		public void Setup()
		{
			m_settlement = new Settlement ();
		}

		[Test ()]
		public void TestPopulationProgressIncreasesWithTurn ()
		{
			var prev = m_settlement.PopulationProgress;
			m_settlement.Turn ();

			Assert.Greater (m_settlement.PopulationProgress, prev);
		}


		[Test ()]
		public void TestPopulationIncreasesWhenProgressIsFull ()
		{
			TestPopulationProgressIncreasesWithTurn ();
			Assert.Greater (m_settlement.PopulationProgress, 0f);
			Assert.Less (m_settlement.PopulationProgress, 1f);

			var prevPopulation = m_settlement.Population;
			float prevProgress;
			do {
				prevProgress = m_settlement.PopulationProgress;
				m_settlement.Turn();
				Assert.Less(m_settlement.PopulationProgress, 1f); //never reaches 1
			}while(m_settlement.PopulationProgress > prevProgress);

			Assert.Greater (m_settlement.Population, prevPopulation);
		}
	}
}

