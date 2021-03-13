using System.Collections.Generic;

namespace BlazorChess.Shared
{
	public class ChessGame
	{
		public ChessBoard   Board        = ChessBoard.DefaultChessBoard;
		public IList<Piece> TakenByWhite = new List<Piece>();
		public IList<Piece> TakenByBlack = new List<Piece>();
	}
}