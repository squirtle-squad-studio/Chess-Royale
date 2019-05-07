using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override List<Vector2Int> GeneratePossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guess = new Vector2Int();

        guess.x = location.x - 1;
        if(guess.x >= 0 && guess.x < 8)
        {
            guess.y = location.y - 1;
            if(guess.y >= 0 && guess.y < 8)
            {
                if(cb.GetPiece(guess) == null || isBlack != cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Add(guess);
                }
            }

            guess.y = location.y;
            if (guess.y >= 0 && guess.y < 8)
            {
                if (cb.GetPiece(guess) == null || isBlack != cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Add(guess);
                }
            }

            guess.y = location.y + 1;
            if (guess.y >= 0 && guess.y < 8)
            {
                if (cb.GetPiece(guess) == null || isBlack != cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Add(guess);
                }
            }
        }

        guess.x = location.x;
        if (guess.x >= 0 && guess.x < 8)
        {
            guess.y = location.y - 1;
            if (guess.y >= 0 && guess.y < 8)
            {
                if (cb.GetPiece(guess) == null || isBlack != cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Add(guess);
                }
            }

            guess.y = location.y + 1;
            if (guess.y >= 0 && guess.y < 8)
            {
                if (cb.GetPiece(guess) == null || isBlack != cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Add(guess);
                }
            }
        }

        guess.x = location.x + 1;
        if (guess.x >= 0 && guess.x < 8)
        {
            guess.y = location.y - 1;
            if (guess.y >= 0 && guess.y < 8)
            {
                if (cb.GetPiece(guess) == null || isBlack != cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Add(guess);
                }
            }

            guess.y = location.y;
            if (guess.y >= 0 && guess.y < 8)
            {
                if (cb.GetPiece(guess) == null || isBlack != cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Add(guess);
                }
            }

            guess.y = location.y + 1;
            if (guess.y >= 0 && guess.y < 8)
            {
                if (cb.GetPiece(guess) == null || isBlack != cb.GetPiece(guess).isBlack)
                {
                    possibleMoves.Add(guess);
                }
            }
        }

        return possibleMoves;
    }

}
