using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : ChessPiece
{
    private void Start()
    {
        location = new Vector2Int((int) gameObject.transform.position.x, (int) gameObject.transform.position.z);

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
