using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    protected override void Start()
    {
        base.Start();
        name = "Pawn";
        if(isBlack)
        {
            moves.Add(new Vector2Int(0,1));
        }
        else
        {
            moves.Add(new Vector2Int(0, -1));
        }
    }

    public override List<Vector2Int> GeneratePossibleMoves(ChessBoard cb)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guessLeft = new Vector2Int();
        Vector2Int guessMiddle = new Vector2Int();
        Vector2Int guessRight = new Vector2Int();
        guessMiddle.x = location.x;

        if (isBlack)
        {
            guessLeft.x = location.x - 1;
            guessLeft.y = location.y + 1;

            guessMiddle.y = location.y + 1;

            guessRight.x = location.x + 1;
            guessRight.y = location.y + 1;
        }
        else
        {
            guessLeft.x = location.x - 1;
            guessLeft.y = location.y - 1;

            guessMiddle.y = location.y - 1;

            guessRight.x = location.x + 1;
            guessRight.y = location.y - 1;
        }

        if (guessLeft.x >= 0 && guessLeft.x < 8 && guessLeft.y >= 0 && guessLeft.y < 8
            && cb.GetPiece(guessLeft) != null)
        {
            if(isBlack != cb.GetPiece(guessLeft).isBlack)
            {
                possibleMoves.Add(guessLeft);
            }
        }

        if (guessMiddle.y >= 0 && guessMiddle.y < 8 && cb.GetPiece(guessMiddle) == null)
        {
            possibleMoves.Add(guessMiddle);
        }

        if (guessRight.x >= 0 && guessRight.x < 8 && guessRight.y >= 0 && guessRight.y < 8
             && cb.GetPiece(guessRight) != null)
        {
            if (isBlack != cb.GetPiece(guessRight).isBlack)
            {
                possibleMoves.Add(guessRight);
            }
        }

        return possibleMoves;
    }
}
