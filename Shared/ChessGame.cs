using System.Collections.Generic;

namespace BlazorChess.Shared
{
	public class ChessGame
	{
		public ChessBoard   Board        { get; set; } = ChessBoard.DefaultChessBoard;
		public IList<Piece> TakenByWhite { get; set; } = new List<Piece>();
		public IList<Piece> TakenByBlack { get; set; } = new List<Piece>();
	}
}