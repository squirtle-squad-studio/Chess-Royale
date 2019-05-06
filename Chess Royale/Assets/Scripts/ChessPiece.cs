using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Steps on making a new chess piece class
 * 1) Your new class must inherit from this class.
 * 2) Override Start() 
 *  I) Your first line should include base.Start(); (so that pieces starts based on gameObject.transform) (Might not need to do this in the future).
 *  II) Override name with your desired name (Used to identify pieces but probably not needed anymore).
 *  III) Add locations of where your piece can move in Vector2Int (Might not need to do this in the future).
 *  IV) Override GeneratePossibleMoves(ChessBoard) with how you want pieces to move.
 *  V) Override Move(Vector2Int) if desired
 *  
 *  Things to consider changing in this class:
 *  The variable name is no longer used. Maybe in the future. (Considering removing this variable)
 *  The variable moves isn't really used that much unless it's unrestricted movement like the horse. (Considering removing this variable)
 *      Reason to remove this variable is due to many of the pieces only use generate possible moves which is independent from the list<Vector2Int> moves.
 *      As a result, if we change the list of moves, it really doesn't change the moves.
 *      Options to solve this problem:
 *      remove the variable moves: (Easiest)
 *      Smartly involve moves in the GeneratePossibleMoves methods for every piece
 */

public abstract class ChessPiece : MonoBehaviour
{
    public new string name;
    public Vector2Int location;
    public bool isBlack;
    public List<Vector2Int> moves; // Default moves (Can pass through other pieces)

    protected virtual void Start()
    {
        location = new Vector2Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.z * -1);
    }

    public virtual List<Vector2Int> GeneratePossibleMoves(ChessBoard cb)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        foreach (Vector2Int element in moves)
        {
            if (location.x + element.x >= 0 && location.y + element.y >= 0
                && location.x + element.x < 8 && location.y + element.y < 8)
            {
                if(cb.GetPiece(element+location) != null && isBlack == cb.GetPiece(element+location).isBlack)
                {
                    continue;
                }
                possibleMoves.Add(element+location);
            }
        }
        return possibleMoves;
    }

    public void Move(Vector2Int cursor)
    {
        if (location != cursor)
        {
            if(cursor.x >= 0 && cursor.x <=8 && cursor.y >= 0 && cursor.y <= 8)
            {
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
