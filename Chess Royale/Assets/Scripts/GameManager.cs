using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("User Interface")]
    public UIManager uiManager;

    [Header("Camera Rotation")]
    public bool isCameraRotation;

    [Header("ChessBoard")]
    public List<GameObject> selectionBoard; // This is a single list taken from a 8x8 board. Advice: please use the helper variable, it's easier.
    public List<ChessPiece> chessPieces;
    private ChessBoard chessBoard;

    // User Input
    private Vector2Int prevCursor; // Where the cursor was before
    private Vector2Int cursor; // Location where cursor is
    private ChessPiece selectedPiece;

    private bool isBlackTurn;

    public CameraMovement cam;

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
        //GraphicsUpdate();
        GetInput();
    }

    private void GraphicsUpdate()
    {
        chessBoard.DeactivateTileAt(prevCursor);
        chessBoard.DisplayPossibleMoveFromSelectedPiece(selectedPiece);
        chessBoard.DisplayKingInCheck();
        chessBoard.SetTileToYellowAt(cursor);

        UIupdate();

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
                //if (selectedPiece.GeneratePossibleMoves() != null && selectedPiece.GeneratePossibleMoves().Contains(cursor))
                if (selectedPiece.GetPossibleMoves() != null && selectedPiece.GetPossibleMoves().Contains(cursor))
                { 
                    if(selectedPiece.isBlack == isBlackTurn)
                    {
                        selectedPiece.Move(cursor);
                        chessBoard.GetKingAttackers(); // To update/check if king is in check after a piece is moved.
                        isBlackTurn = !isBlackTurn;

                        // Rotation
                        if(isCameraRotation)
                        {
                            cam.NextPlayerCam();
                        }
                    }
                }
                // Deselects the piece and clears possible moves
                selectedPiece = null;
                chessBoard.ClearSelectionBoard();
            }
            GraphicsUpdate();
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
            if (isBlackTurn && isCameraRotation)
            {
                if (cursor.y + 1 >= 0 && cursor.y + 1 < 8)
                {
                    cursor.y += 1;
                }
            }
            else
            {
                if (cursor.y - 1 >= 0 && cursor.y - 1 < 8)
                {
                    cursor.y -= 1;
                }
            }
            GraphicsUpdate();
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if(isBlackTurn && isCameraRotation)
            {
                if (cursor.x + 1 >= 0 && cursor.x + 1 < 8)
                {
                    cursor.x += 1;
                }
            }
            else
            {
                if (cursor.x - 1 >= 0 && cursor.x - 1 < 8)
                {
                    cursor.x -= 1;
                }
            }
            GraphicsUpdate();
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (isBlackTurn && isCameraRotation)
            {
                if (cursor.y - 1 >= 0 && cursor.y - 1 < 8)
                {
                    cursor.y -= 1;
                }
            }
            else
            {
                if (cursor.y + 1 >= 0 && cursor.y + 1 < 8)
                {
                    cursor.y += 1;
                }
            }
            GraphicsUpdate();
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (isBlackTurn && isCameraRotation)
            {
                if (cursor.x - 1 >= 0 && cursor.x - 1 < 8)
                {
                    cursor.x -= 1;
                }
            }
            else
            {
                if (cursor.x + 1 >= 0 && cursor.x + 1 < 8)
                {
                    cursor.x += 1;
                }
            }
            GraphicsUpdate();
        }
    }

    private void UIupdate()
    {
        if(chessBoard.isWhiteKingInCheck)
        {
            uiManager.WhiteKingInCheck();
        }
        if (chessBoard.isBlackKingInCheck)
        {
            uiManager.BlackKingInCheck();
        }
        if(!chessBoard.isBlackKingInCheck && !chessBoard.isWhiteKingInCheck)
        {
            uiManager.DeactivateText();
        }
        if(chessBoard.gameOver)
        {
            uiManager.GameOver();
        }
    }

}
