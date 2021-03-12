namespace BlazorChess.Shared
{
	public class ChessBoardCell
	{
		public Piece? Piece;
		public bool  IsBlack;
		public char?  Character => Piece?.GetChar(IsBlack);
	}
}