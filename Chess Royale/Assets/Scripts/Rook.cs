using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override List<Vector2Int> GeneratePossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        List<Vector2Int> temp;

        temp = RookMoves(true, true);
        if (temp != null)
        {
            foreach(Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = RookMoves(false, true);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = RookMoves(true, false);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = RookMoves(false, false);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }


        return possibleMoves;
    }

    /**
     * isPositive is the positive or negative direction
     * isXDirection is the X axis or Y axis
     */
    private List<Vector2Int> RookMoves(bool isPositive, bool isXDirection)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guess = new Vector2Int();

        if(isXDirection)
        {
            guess.y = location.y;
        }
        else
        {
            guess.x = location.x;
        }

        for (int i = 1; i < 8; i++)
        {
            if (isPositive)
            {
                if(isXDirection)
                {
                    guess.x = location.x + i;
                }
                else
                {
                    guess.y = location.y + i;
                }
            }
            else
            {
                if (isXDirection)
                {
                    guess.x = location.x - i;
                }
                else
                {
                    guess.y = location.y - i;
                }
            }


            /*
             * Logic as we take the next step
             */
            if (IsWithinBorderBound(guess))
            {
                if (cb.GetPiece(guess) == null)
                {
                    possibleMoves.Add(guess);
                }
                else
                {
                    if (IsSameColorAs(cb.GetPiece(guess)))
                    {
                        break;
                    }
                    else
                    {
                        possibleMoves.Add(guess);
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }

        return possibleMoves;
    }
}
