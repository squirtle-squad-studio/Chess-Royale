using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    public override List<Vector2Int> GeneratePossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guess = new Vector2Int();

        for(int i = 1; i < 8; i++)
        {
            guess.x = location.x + i;
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

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x - i;
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

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x - i;
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
            guess.x = location.x + i;
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

        return possibleMoves;
    }
}
