using System;
using System.Collections.Generic;

namespace Undersea
{
	public abstract class GameRules
	{
		public GameRules (int gridSizeX, int gridSizeY)
		{
			m_gameStart = DateTime.Now;
			m_lastTick = DateTime.Now;
			m_grid = new Grid(gridSizeX, gridSizeY);
		}
		
		private static GameRules m_currentGameRules;
		
		public static GameRules GetGameRules()
		{
			return m_currentGameRules;
		}
		
		public static void StartNewGame(GameRules rules)
		{
			m_currentGameRules = rules;
			rules.StartGame();
		}
		
		protected DateTime m_gameStart;
		protected DateTime m_lastTick;
		protected bool m_gameRunning;
		protected Grid m_grid;
		protected List<Actor> m_actors;
		
		public virtual void Process()
		{
			DateTime currentTime = DateTime.Now;
			int gameTimePassed = (int)((currentTime.Ticks - m_lastTick.Ticks) / 10);
			
			if (CheckGameEnded()) 
			{
				if (m_gameRunning)
				{
					// Stop the game and declare a winner.
				}
			}
			else
			{
				m_grid.Process(gameTimePassed);
				foreach (Actor actor in m_actors)
				{
					actor.Process(gameTimePassed);
				}
			}
		}
		
		public abstract void StartGame();
		public abstract bool CheckGameEnded();
		public abstract int GetWinner();
	}
}

