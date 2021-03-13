namespace BlazorChess.Shared
{
	public class ChessBoardCell
	{
		public Piece? Piece { get; set; }
		public bool  IsBlack { get; set; }
		public char?  Character => Piece?.GetChar(IsBlack);
	}
}