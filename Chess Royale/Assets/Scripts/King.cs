using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        name = "King";

        moves.Add(new Vector2Int(1,1));
        moves.Add(new Vector2Int(-1, 1));
        moves.Add(new Vector2Int(1, -1));
        moves.Add(new Vector2Int(-1, -1));
        moves.Add(new Vector2Int(0, 1));
        moves.Add(new Vector2Int(-1, 0));
        moves.Add(new Vector2Int(0, -1));
        moves.Add(new Vector2Int(1, 0));
    }
}
