using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChess.Server.Hubs
{
	public class ChessHub : Hub
	{
		public async Task SendMove(string startPos, string endPos)
		{
			await Clients.All.SendAsync("ReceiveMove", startPos, endPos);
		}
	}
}