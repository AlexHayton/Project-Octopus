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
			Renderer.GetRenderer().AddRenderObject(m_grid);
			
			Octopus octopus = new Octopus();
			octopus.SetGridPosition(new GridCoord(10,10));
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

