using System;
using ChessDotNet;
using ChessDotNet.Pieces;

namespace BlazorChess.Shared
{
	public static class ChessProcessor
	{
		public static bool MoveIsValid(ChessBoard board, int startIndex, int endIndex)
		{
			var move = new Move(startIndex.GetChessDotNetPosition(), endIndex.GetChessDotNetPosition(), board.Cells[startIndex].IsBlack.ChessDotNetPlayer());

			var gameCreationData = new GameCreationData();
			for (var i = 0; i < 8; i++)
				for (var j = 0; j < 8; j++)
				{
					var cell = board.Cells[i *j];
					gameCreationData.Board[i][j] = cell.Piece.Value.ChessDotNetPiece(cell.IsBlack);
				}

			var game = new ChessDotNet.ChessGame(gameCreationData);

			return game.IsValidMove(move);
		}

		private static Position GetChessDotNetPosition(this int index)
		{
			var rank = index / 8 + 1;
			var file = index - rank switch
			{
				0 => File.A,
				1 => File.B,
				2 => File.C,
				3 => File.D,
				4 => File.E,
				5 => File.F,
				6 => File.G,
				7 => File.H,
				_ => throw new ArgumentOutOfRangeException()
			};

			return new(file, rank);
		}

		private static ChessDotNet.Player ChessDotNetPlayer(this bool isBlack) => isBlack
			? ChessDotNet.Player.Black
			: ChessDotNet.Player.White;

		private static ChessDotNet.Piece ChessDotNetPiece(this Piece piece, bool isBlack) => piece switch
		{
			Piece.Pawn   => new Pawn(isBlack ? ChessDotNet.Player.Black : ChessDotNet.Player.White),
			Piece.King   => new King(isBlack ? ChessDotNet.Player.Black : ChessDotNet.Player.White),
			Piece.Queen  => new Queen(isBlack ? ChessDotNet.Player.Black : ChessDotNet.Player.White),
			Piece.Knight => new Knight(isBlack ? ChessDotNet.Player.Black : ChessDotNet.Player.White),
			Piece.Bishop => new Bishop(isBlack ? ChessDotNet.Player.Black : ChessDotNet.Player.White),
			Piece.Rook   => new Rook(isBlack ? ChessDotNet.Player.Black : ChessDotNet.Player.White),
			_            => throw new ArgumentOutOfRangeException(nameof(piece), piece, null)
		};
	}

	public enum Player
	{
		White, Black
	}
}