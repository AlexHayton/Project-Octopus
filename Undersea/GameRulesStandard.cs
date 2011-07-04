using System;
namespace Undersea
{
	public class GameRulesStandard : GameRules
	{
		public GameRulesStandard (int sizeX, int sizeY) : base(sizeX, sizeY)
		{
		}
		
		public override void StartGame()
		{
		}
		
		public override bool CheckGameEnded()
		{
			return false;
		}
		
		public override int GetWinner()
		{
			return 1;
		}
	}
}

