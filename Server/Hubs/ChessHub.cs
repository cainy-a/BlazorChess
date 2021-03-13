using System.Threading.Tasks;
using BlazorChess.Server.Services;
using BlazorChess.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChess.Server.Hubs
{
	public class ChessHub : Hub
	{
		private IGameStorageService _storageService;
		public ChessHub(IGameStorageService storageService) { _storageService = storageService; }

		public async Task SendMove(int startPos, int endPos)
		{
			await Clients.Others.SendAsync("ReceiveMove", startPos, endPos);
		}
		
		public async Task AskForGame(string gameId)
		{
			var game = _storageService.GetGame(gameId);
			if (game != null)
				await Clients.Caller.SendAsync("ReceiveGame", game);
		}

		public async Task SendGame(string gameId, ChessGame game) => _storageService.SetGame(gameId, game);
	}
}