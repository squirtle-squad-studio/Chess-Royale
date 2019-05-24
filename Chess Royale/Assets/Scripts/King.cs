using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    //public bool isCheck;
    //protected override void Start()
    //{
    //    base.Start();
    //    isCheck = false;
    //}

    public override List<Vector2Int> GetPossibleMoves()
    {
        List<Vector2Int> possibleMoves = GeneratePossibleMoves();
        cb.GetKingAttackers();
        if(ChessPiece.kingAttackers == null || ChessPiece.kingAttackers.Count == 0) { return possibleMoves; }
        if (ChessPiece.kingAttackers.Count <= 1 && ChessPiece.kingAttackers[0].isBlack != isBlack)
        {
            List<Vector2Int> temp = new List<Vector2Int>();
            foreach (Vector2Int element in possibleMoves)
            {
                foreach (ChessPiece chessP in cb.listOfChessPieces)
                {
                    if (chessP.GeneratePossibleMoves().Contains(element) && chessP.isBlack != isBlack)
                    {
                        temp.Add(element);
                    }
                }
            }
            // Removes check moves
            foreach (Vector2Int element in temp)
            {
                possibleMoves.Remove(element);
            }
        }
        else if (ChessPiece.kingAttackers.Count > 1 && ChessPiece.kingAttackers[0].isBlack != isBlack)
        {
            return new List<Vector2Int>();
        }
        return possibleMoves;
    }
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
