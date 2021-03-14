using System;
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

		public async Task SendMove(string gameId, int startPos, int endPos)
		{
			var board = _storageService.GetGame(gameId)?.Board ?? ChessBoard.DefaultChessBoard;
			if (ChessProcessor.MoveIsValid(board, startPos, endPos))
				await Clients.Others.SendAsync("ReceiveMove", startPos, endPos);
			else
				Console.WriteLine("Illegal move sent");
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