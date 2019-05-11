using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override List<Vector2Int> GeneratePossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guess = new Vector2Int();

        guess.x = location.x + 1;
        guess.y = location.y;
        if(KingMoves(guess))
        {
            possibleMoves.Add(guess);
        }

        guess.x = location.x + 1;
        guess.y = location.y + 1;
        if (KingMoves(guess))
        {
            possibleMoves.Add(guess);
        }

        guess.x = location.x + 1;
        guess.y = location.y - 1;
        if (KingMoves(guess))
        {
            possibleMoves.Add(guess);
        }

        guess.x = location.x;
        guess.y = location.y + 1;
        if (KingMoves(guess))
        {
            possibleMoves.Add(guess);
        }

        guess.x = location.x;
        guess.y = location.y - 1;
        if (KingMoves(guess))
        {
            possibleMoves.Add(guess);
        }

        guess.x = location.x - 1;
        guess.y = location.y;
        if (KingMoves(guess))
        {
            possibleMoves.Add(guess);
        }

        guess.x = location.x - 1;
        guess.y = location.y + 1;
        if (KingMoves(guess))
        {
            possibleMoves.Add(guess);
        }

        guess.x = location.x - 1;
        guess.y = location.y - 1;
        if (KingMoves(guess))
        {
            possibleMoves.Add(guess);
        }

        return possibleMoves;
    }

    private bool KingMoves(Vector2Int v)
    {
        if(IsWithinBorderBound(v.x, v.y))
        {
            if(cb.GetPiece(v.x, v.y) == null 
                || cb.GetPiece(v.x, v.y) != null && !IsSameColorAs(cb.GetPiece(v.x, v.y)))
            {
                return true;
            }
        }
        return false;
    }

}
