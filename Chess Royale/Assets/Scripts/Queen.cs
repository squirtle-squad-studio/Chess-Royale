using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    public override List<Vector2Int> GetPossibleMoves()
    {
        cb.GetKingAttackers();
        List<Vector2Int> possibleMoves = PossibleMoveCheckFilter( GeneratePossibleMoves());
        return possibleMoves;
    }
    public override List<Vector2Int> GeneratePossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        List<Vector2Int> temp = new List<Vector2Int>();

        temp = QueenMoves(false, false, false);
        if(temp != null)
        {
            foreach(Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = QueenMoves(false, false, true);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = QueenMoves(false, true, false);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = QueenMoves(false, true, true);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }


        temp = QueenMoves(true, false, false);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = QueenMoves(true, false, true);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = QueenMoves(true, true, false);
        if (temp != null)
        {
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Add(element);
            }
        }

        temp = QueenMoves(true, true, true);
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
     * if (isRook) -> RookMoves(isPositive, isXDirection)
     * a = isPositive, b = isXDirection
     * if (!isRook) -> BishopMoves(isRight, isUp)
     * a = isRight, b = isUp
     */
    private List<Vector2Int> QueenMoves(bool isRook, bool a, bool b)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guess = new Vector2Int();

        if (isRook)
        {

            if (b)
            {
                guess.y = location.y;
            }
            else
            {
                guess.x = location.x;
            }

            for (int i = 1; i < 8; i++)
            {
                if (a)
                {
                    if (b)
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
                    if (b)
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
        }
        else // Bishop
        {

            for (int i = 1; i < 8; i++)
            {
                if (a)
                {
                    guess.x = location.x + i;
                }
                else
                {
                    guess.x = location.x - i;
                }

                if (b)
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
        }
        return possibleMoves;
    }
}
