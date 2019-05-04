using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    protected override void Start()
    {
        base.Start();
        name = "Rook";

        for(int row = -7; row < 8; row++)
        {
            moves.Add(new Vector2Int(0, row));
        }
        for (int col = -7; col < 8; col++)
        {
            moves.Add(new Vector2Int(col, 0));
        }
    }

    public override List<Vector2Int> GeneratePossibleMoves(ChessBoard cb)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guess = new Vector2Int();

        for(int i = 1; i < 8; i++)
        {
            guess.x = location.x - i;
            guess.y = location.y;
            if(guess.x < 0 || guess.y < 0 || guess.x >7 || guess.y > 7)
            {
                break;
            }
            possibleMoves.Add(guess);
            if (cb.GetPiece(guess) != null)
            {
                if (this.isBlack == cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Remove(guess);
                }
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x + i;
            guess.y = location.y;
            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }
            possibleMoves.Add(guess);
            if (cb.GetPiece(guess) != null)
            {
                if (this.isBlack == cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Remove(guess);
                }
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x;
            guess.y = location.y - i;
            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }
            possibleMoves.Add(guess);
            if (cb.GetPiece(guess) != null)
            {
                if (this.isBlack == cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Remove(guess);
                }
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x;
            guess.y = location.y + i;
            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }
            possibleMoves.Add(guess);
            if (cb.GetPiece(guess) != null)
            {
                if (this.isBlack == cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Remove(guess);
                }
                break;
            }
        }

        return possibleMoves;
    }
}
