using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector2Int> GetPossibleMoves()
    {
        cb.GetKingAttackers();
        List<Vector2Int> possibleMoves = PossibleMoveCheckFilter(GeneratePossibleMoves());
        return possibleMoves;
    }
    public override List<Vector2Int> GeneratePossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int Vect2Null = new Vector2Int(-1, -1); // To check for invalid move let say that (-1,-1) means null
        Vector2Int temp;

        temp = KnightMoves(false, false, false);
        if (temp != Vect2Null)
        {
            possibleMoves.Add(temp);
        }

        temp = KnightMoves(false, false, true);
        if (temp != Vect2Null)
        {
            possibleMoves.Add(temp);
        }

        temp = KnightMoves(false, true, false);
        if (temp != Vect2Null)
        {
            possibleMoves.Add(temp);
        }

        temp = KnightMoves(false, true, true);
        if (temp != Vect2Null)
        {
            possibleMoves.Add(temp);
        }

        temp = KnightMoves(true, false, false);
        if (temp != Vect2Null)
        {
            possibleMoves.Add(temp);
        }

        temp = KnightMoves(true, false, true);
        if (temp != Vect2Null)
        {
            possibleMoves.Add(temp);
        }

        temp = KnightMoves(true, true, false);
        if (temp != Vect2Null)
        {
            possibleMoves.Add(temp);
        }

        temp = KnightMoves(true, true, true);
        if (temp != Vect2Null)
        {
            possibleMoves.Add(temp);
        }
        return possibleMoves;
    }

    /**
     * isRight is the positive/negative X-axis
     * isUp is the postivive/negative Y-axis
     * isFirstMoveSet = (2,1), !isFirstMoveSet = (1,2)
     */
    private Vector2Int KnightMoves(bool isRight, bool isUp, bool isFirstMoveSet)
    {
        Vector2Int guess = new Vector2Int();

        if(isRight)
        {
            if(isFirstMoveSet)
            {
                guess.x = location.x + 2;
            }
            else
            {
                guess.x = location.x + 1;
            }
        }
        else
        {
            if (isFirstMoveSet)
            {
                guess.x = location.x - 2;
            }
            else
            {
                guess.x = location.x - 1;
            }
        }
        if(isUp)
        {
            if (isFirstMoveSet)
            {
                guess.y = location.y + 1;
            }
            else
            {
                guess.y = location.y + 2;
            }
        }
        else
        {
            if (isFirstMoveSet)
            {
                guess.y = location.y - 1;
            }
            else
            {
                guess.y = location.y - 2;
            }
        }

        /*
         * Logic here
         */
        if(IsWithinBorderBound(guess))
        {
            if (cb.GetPiece(guess) == null || !IsSameColorAs(cb.GetPiece(guess)))
            {
                return guess;
            }
        }
        return new Vector2Int(-1, -1);
    }
}
