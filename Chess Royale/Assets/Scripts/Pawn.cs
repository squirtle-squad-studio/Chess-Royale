using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    private bool specialMove; // Jumps twice
    protected override void Start()
    {
        base.Start();
        specialMove = true;
    }
    public override List<Vector2Int> GetPossibleMoves()
    {
        cb.GetKingAttackers();

        List<Vector2Int> possibleMoves = PossibleMoveCheckFilter(GeneratePossibleMoves());

        return possibleMoves;
    }
    public override List<Vector2Int> GeneratePossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int temp = new Vector2Int();
        temp.x = location.x;

        if (isBlack)
        {
            temp.y = location.y + 1;
        }
        else
        {
            temp.y = location.y - 1;
        }

        // Middle
        if (IsWithinBorderBound(temp) && cb.GetPiece(temp) == null)
        {
            possibleMoves.Add(temp);

            // Special Move
            if (specialMove)
            {
                if (isBlack)
                {
                    temp.y += 1;
                }
                else
                {
                    temp.y -= 1;
                }
                if (IsWithinBorderBound(temp) && cb.GetPiece(temp) == null)
                {
                    possibleMoves.Add(temp);
                }

                // Resets it to 1 squares foward
                if (isBlack)
                {
                    temp.y -= 1;
                }
                else
                {
                    temp.y += 1;
                }
            }
        }

        // Right
        temp.x += 1;
        if (IsWithinBorderBound(temp) && cb.GetPiece(temp) != null && !IsSameColorAs(cb.GetPiece(temp)))
        {
            possibleMoves.Add(temp);
        }

        //Left
        temp.x -= 2;
        if (IsWithinBorderBound(temp) && cb.GetPiece(temp) != null && !IsSameColorAs(cb.GetPiece(temp)))
        {
            possibleMoves.Add(temp);
        }
        return possibleMoves;
    }

    public override void Move(Vector2Int cursor)
    {
        base.Move(cursor);
        if(specialMove == true)
        {
            specialMove = false;
        }
    }
}
