using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * To make a new Chess piece, you need to:
 * 1) inherit from ChessPiece
 * 2) Override GeneratePossibleMoves()
 * 3) Probably override Move() for special moves
 */

public abstract class ChessPiece : MonoBehaviour
{
    public Vector2Int location;
    public bool isBlack;
    private bool isCaptured;

    protected ChessBoard cb;

    protected virtual void Start()
    {
        isCaptured = false;
        location = new Vector2Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.z * -1);
    }

    public abstract List<Vector2Int> GeneratePossibleMoves();

    public void SetChessBoard(ChessBoard chessBoard)
    {
        cb = chessBoard;
    }

    public virtual void Move(Vector2Int cursor)
    {
        if (location != cursor)
        {
            if(cursor.x >= 0 && cursor.x <=8 && cursor.y >= 0 && cursor.y <= 8)
            {
                if(cb.GetPiece(cursor) != null)
                {
                    cb.RemovePieceAt(cursor);
                }
                location = cursor;
                gameObject.transform.position = new Vector3(cursor.x, 1, -1 * cursor.y);

            }
            else
            {
                Debug.Log("Invalid Move at" + cursor);
            }
        }

    }
}
