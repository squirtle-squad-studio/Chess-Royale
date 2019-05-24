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

    protected ChessBoard cb;
    public static List<ChessPiece> kingAttackers; // Used as "Check", Count == 0 means not in check

    public void Awake()
    {
        if(kingAttackers == null)
        {
            kingAttackers = new List<ChessPiece>();
        }
    }

    protected virtual void Start()
    {
        location = new Vector2Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.z * -1);
    }
    // GeneratePossibleMoves() is a method that generates moves but doesn't care about when a king is in check
    public abstract List<Vector2Int> GeneratePossibleMoves();
    // GetPossibleMoves() is a method that uses GeneratePossibleMoves() but filter out moves
    public abstract List<Vector2Int> GetPossibleMoves();

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

    /**
     * This method is used in the GeneratePossibleMoves() to filter out moves when king is in check
     * @param input is where the unfiltered move list are (Moves that don't account for check)
     */
    protected List<Vector2Int> PossibleMoveCheckFilter(List<Vector2Int> input)
    {
        // Check for empty list
        if (input != null)
        {
            // Check if the list is not empty
            if(input.Count > 0)
            {
                if (kingAttackers.Count == 0)
                {
                    return input;
                }
                if(kingAttackers[0].isBlack != isBlack)
                {
                    // When there's only one piece then,
                    // 1) You can move it
                    // 2) Block it
                    // 3) Capture the attacking piece
                    if (kingAttackers.Count == 1)
                    {
                        List<Vector2Int> filteredList = new List<Vector2Int>();
                        Vector2Int currentLocation = location; // This variable is used to record what our current location is
                        ChessPiece attacker = kingAttackers[0];
                        ChessPiece king;
                        // King
                        if (isBlack)
                        {
                            king = cb.blackKing;
                        }
                        else
                        {
                            king = cb.whiteKing;
                        }

                        // This loop search for each inputs that can "uncheck"
                        // Note that we are using this piece's location but not the actual game transform
                        // So this doesn't have any appearance in game
                        foreach(Vector2Int element in input)
                        {
                            location = element;
                            if (location == attacker.location)
                            {
                                filteredList.Add(element);
                            }
                            else if (attacker.GeneratePossibleMoves().Contains(king.location))
                            {
                                continue;
                            }

                            filteredList.Add(element);
                        }
                        location = currentLocation; // resets the location to where it was
                        cb.UpdateBoard();
                        return filteredList;
                    }
                    else
                    {
                        //Debug.Log("PossibleMoveCheckFilter: Multiple attack on king");
                        return null;
                    }
                }
                else
                {
                    //Debug.Log("PossibleMoveCheckFilter: @Param elements are not enemies");
                    return null;
                }
            }
            else
            {
                //Debug.Log("PossibleMoveCheckFilter: @Param is !null but empty list");
                return null;
            }
        }
        else
        {
            //Debug.Log("PossibleMoveCheckFilter: @Param input is null");
            return null;
        }
    }

    /**
     * Checks if the v relative to the current location is within the chess boundary
     */
    protected bool IsWithinBorderBound(Vector2Int v)
    {
        if(v.x >= 0 && v.x < 8
            && v.y >= 0 && v.y < 8)
        {
            return true;
        }
        return false;
    }
    protected bool IsWithinBorderBound(int x, int y)
    {
        if (x >= 0 && x < 8
            && y >= 0 && y < 8)
        {
            return true;
        }
        return false;
    }

    protected bool IsSameColorAs(ChessPiece element)
    {
        return isBlack == element.isBlack;
    }
}
