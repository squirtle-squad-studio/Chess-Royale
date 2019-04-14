using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public string name;
    public Vector2Int location;
    public List<Vector2Int> moves;

    private void Start()
    {
        location = new Vector2Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.z);
    }
    public List<Vector2Int> GetPossibleMoves()
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        foreach(Vector2Int element in moves)
        {
            if(element.x + location.x >= 0 && element.x + location.x < 8)
            {
                if(element.y + location.y >= 0 && element.y + location.y < 8)
                {
                    possibleMoves.Add(new Vector2Int(element.x + location.x, element.y + location.y));
                }
            }
        }
        return possibleMoves;
    }

    /**
     * Bug: Range Out of Bounds exception
     * 
     * */
    public void Move(Vector2Int cursor)
    {
        if (location != cursor)
        {
            List<Vector2Int> possibleMoves = GetPossibleMoves();
            bool moveAble = false;
            if(possibleMoves.Count > 0)
            {
                foreach(Vector2Int element in possibleMoves)
                {
                    if (cursor == element)
                    {
                        moveAble = true;
                        //location = cursor;
                        location.x = cursor.x;
                        location.y = cursor.y;
                        transform.position = new Vector3(cursor.x, 1, -1 * cursor.y);

                        Debug.Log("(" + location.x + "," + location.y + ")");
                    }
                }
            }

            if (!moveAble)
            {
                Debug.Log("Else reached");
            }
        }

    }
}
