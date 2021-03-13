using static BlazorChess.Shared.Piece;

namespace BlazorChess.Shared
{
	public class ChessBoard
	{
		public ChessBoardCell[] Cells { get; set; } = new ChessBoardCell[64];

		public static ChessBoard DefaultChessBoard
		{
			get
			{
				return new ChessBoard {Cells = new []
			{
				B(Rook), B(Knight), B(Bishop), B(Queen), B(King), B(Bishop), B(Knight), B(Rook),
				B(Pawn), B(Pawn), B(Pawn), B(Pawn), B(Pawn), B(Pawn), B(Pawn), B(Pawn),
				E(), E(), E(), E(), E(), E(), E(), E(),
				E(), E(), E(), E(), E(), E(), E(), E(),
				E(), E(), E(), E(), E(), E(), E(), E(),
				E(), E(), E(), E(), E(), E(), E(), E(),
				W(Pawn), W(Pawn), W(Pawn), W(Pawn), W(Pawn), W(Pawn), W(Pawn), W(Pawn),
				W(Rook), W(Knight), W(Bishop), W(Queen), W(King), W(Bishop), W(Knight), W(Rook)
			}};
				static ChessBoardCell W(Piece piece) => new() {Piece = piece}; // white piece
				static ChessBoardCell B(Piece piece) => new() {Piece = piece, IsBlack = true}; // black piece
				static ChessBoardCell E()            => new(); // empty square
			}
		}
	}
}