using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    public override List<Vector2Int> GeneratePossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        List<Vector2Int> temp = new List<Vector2Int>();

        temp = BishopMoves(false, false);
        if(temp != null)
        {
            foreach(Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = BishopMoves(false, true);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = BishopMoves(true, false);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = BishopMoves(true, true);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        return possibleMoves;
    }

    private List<Vector2Int> BishopMoves(bool isRight, bool isUp)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guess = new Vector2Int();

        for (int i = 1; i < 8; i++)
        {
            if (isRight)
            {
                guess.x = location.x + i;
            }
            else
            {
                guess.x = location.x - i;
            }

            if(isUp)
            {
                guess.y = location.y + i;
            }
            else
            {
                guess.y = location.y - i;
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
