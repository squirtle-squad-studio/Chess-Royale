using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    protected void Start()
    {
        base.Start();
        name = "Rook";

        for(int row = 0; row < 8; row++)
        {
            moves.Add(new Vector2Int(0, row));
            moves.Add(new Vector2Int(0, -1 * row));
        }
        for (int col = 0; col < 8; col++)
        {
            moves.Add(new Vector2Int(col, 0));
            moves.Add(new Vector2Int(-1 * col, 0));
        }
    }
}
