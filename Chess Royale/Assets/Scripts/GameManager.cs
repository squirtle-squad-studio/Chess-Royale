using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> selectionBoard; // This is a single list taken from a 8x8 board. Advice: please use the helper variable, it's easier.
    public List<ChessPiece> chessPieces;
    private ChessBoard chessBoard;

    // User Input
    private Vector2Int prevCursor; // Where the cursor was before
    private Vector2Int cursor; // Location where cursor is
    private ChessPiece selectedPiece;

    private bool isBlackTurn;

    // Start is called before the first frame update
    void Start()
    {
        cursor = new Vector2Int(0,0);
        chessBoard = new ChessBoard(selectionBoard, chessPieces);

        chessBoard.ClearSelectionBoard(); 
        chessBoard.SetTileToYellowAt(cursor);
        isBlackTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        GraphicsUpdate();
        GetInput();
    }

    private void GraphicsUpdate()
    {
        chessBoard.DisplayPossibleMoveFromSelectedPiece(selectedPiece);
        chessBoard.DeactivateTileAt(prevCursor);
        chessBoard.SetTileToYellowAt(cursor);

        prevCursor = cursor; // Updates the prevCursor
    }


    private void GetInput() {

        //-----------------------------------------------------------------------
        // These two if statements are the most important to focus on.
        
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (selectedPiece == null)
            {
                if (chessBoard.GetPiece(cursor) != null)
                {
                    selectedPiece = chessBoard.GetPiece(cursor);
                }
            }
            else
            { 
                // This is when we have try to move our selectedPiece to a square
                if (selectedPiece.GeneratePossibleMoves() != null && selectedPiece.GeneratePossibleMoves().Contains(cursor))
                {
                    if(selectedPiece.isBlack == isBlackTurn)
                    {
                        selectedPiece.Move(cursor);
                        isBlackTurn = !isBlackTurn;
                    }
                }
                // Deselects the piece and clears possible moves
                selectedPiece = null;
                chessBoard.ClearSelectionBoard();
            }

        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            chessBoard.ClearSelectionBoard();
            chessBoard.SetTileToYellowAt(cursor);
            selectedPiece = null;
        }

        //
        //-----------------------------------------------------------------------


        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            if(cursor.y - 1 >= 0 && cursor.y - 1 < 8)
            {
                cursor.y -= 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (cursor.x - 1 >= 0 && cursor.x - 1 < 8)
            {
                cursor.x -= 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (cursor.y + 1 >= 0 && cursor.y + 1 < 8)
            {
                cursor.y += 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (cursor.x + 1 >= 0 && cursor.x + 1 < 8)
            {
                cursor.x += 1;
            }
        }
    }

}
