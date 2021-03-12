using System;

namespace BlazorChess.Shared
{
	public static class Utils
	{
		public static char GetChar(this Piece piece, bool isBlack) => piece switch
		{
			Piece.Pawn   => isBlack ? '♟' : '♙',
			Piece.King   => isBlack ? '♚' : '♔',
			Piece.Queen  => isBlack ? '♛' : '♕',
			Piece.Knight => isBlack ? '♞' : '♘',
			Piece.Bishop => isBlack ? '♝' : '♗',
			Piece.Rook   => isBlack ? '♜' : '♖',
			_            => throw new ArgumentOutOfRangeException(nameof(piece), piece, null)
		};
	}
}