using System.Collections.Generic;
using BlazorChess.Shared;

namespace BlazorChess.Server.Services
{
	public class GameStorageService : IGameStorageService
	{
		private Dictionary<string, ChessGame> _games = new();

		public ChessGame GetGame(string gameId) => _games.TryGetValue(gameId, out var game) ? game : null;
		public void      SetGame(string gameId, ChessGame game) => _games[gameId] = game;
	}
}