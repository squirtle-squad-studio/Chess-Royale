using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    protected void Start()
    {
        base.Start();
        name = "Knight";
        moves.Add(new Vector2Int(-1, 2));
        moves.Add(new Vector2Int(-1, -2));
        moves.Add(new Vector2Int(1, 2));
        moves.Add(new Vector2Int(1, -2));

        moves.Add(new Vector2Int(-2, 1));
        moves.Add(new Vector2Int(-2, -1));
        moves.Add(new Vector2Int(2, 1));
        moves.Add(new Vector2Int(2, -1));
    }
}
