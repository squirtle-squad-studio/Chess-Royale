using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : ChessPiece
{
    private void Start()
    {
        name = "Horse";
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
