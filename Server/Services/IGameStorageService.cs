using BlazorChess.Shared;

namespace BlazorChess.Server.Services
{
	public interface IGameStorageService
	{
		ChessGame GetGame(string gameId);
		void      SetGame(string gameId, ChessGame game);
	}
}