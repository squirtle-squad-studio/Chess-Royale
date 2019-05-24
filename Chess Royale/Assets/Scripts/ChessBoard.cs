using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard
{
    private List<GameObject> selectionBoard;
    public List<ChessPiece> listOfChessPieces; // Actual Chess Pieces
    private ChessPiece[,] chessPieces; // Same as listOfChessPieces but with Location of where the pieces are

    private GameObject[,] selectionBoardHelper; // selectionBoard but in 2D array
    private ColorChanger[,] selectionBoardColorArray; // selectionBoard but in 2D array

    public List<ChessPiece> BlackCapturedPieces { get; }
    public List<ChessPiece> WhiteCapturedPieces { get; }

    public bool isWhiteKingInCheck { get; private set; }
    public bool isBlackKingInCheck { get; private set; }

    // King pieces
    // For location purposes
    // Used to know if it's check
    [HideInInspector]public ChessPiece whiteKing;
    [HideInInspector]public ChessPiece blackKing;

    public bool gameOver;

    public ChessBoard(List<GameObject> mySelectionBoard, List<ChessPiece> cp)
    {
        gameOver = false;

        selectionBoard = mySelectionBoard;
        BlackCapturedPieces = new List<ChessPiece>();
        WhiteCapturedPieces = new List<ChessPiece>();

        isWhiteKingInCheck = false;
        isBlackKingInCheck = false;

        InitiateSelectionBoardHelper();
        InitiateSelectionBoardColorArray();
        InitiateAndFillChessPieces(cp);
        InitializePiecesToReference();

        FindKings();
    }

    public ChessPiece GetPiece(Vector2Int v)
    {
        UpdateBoard();
        return chessPieces[v.x, v.y];
    }

    public ChessPiece GetPiece(int x, int y)
    {
        UpdateBoard();
        return chessPieces[x, y];
    }

    public void RemovePieceAt(Vector2Int v)
    {
        if(chessPieces[v.x, v.y] != null)
        {
            if(chessPieces[v.x, v.y].isBlack == true)
            {
                chessPieces[v.x, v.y].transform.position = new Vector3(BlackCapturedPieces.Count, 0, -9);
                BlackCapturedPieces.Add(chessPieces[v.x, v.y]);
            }
            else
            {
                chessPieces[v.x, v.y].transform.position = new Vector3(WhiteCapturedPieces.Count, 0, 2);
                WhiteCapturedPieces.Add(chessPieces[v.x, v.y]);
            }
            listOfChessPieces.Remove(chessPieces[v.x, v.y]);
            chessPieces[v.x, v.y] = null; // Just to be safe (Maybe this is needed)
        }
    }
    public void RemovePieceAt(int x, int y)
    {
        if (chessPieces[x, y] != null)
        {
            if (chessPieces[x, y].isBlack == true)
            {
                chessPieces[x, y].transform.position = new Vector3(BlackCapturedPieces.Count, 0, -9);
                BlackCapturedPieces.Add(chessPieces[x, y]);
            }
            else
            {
                chessPieces[x, y].transform.position = new Vector3(WhiteCapturedPieces.Count, 0, 2);
                WhiteCapturedPieces.Add(chessPieces[x, y]);
            }
            listOfChessPieces.Remove(chessPieces[x, y]);
            chessPieces[x, y] = null; // Just to be safe (Maybe this is needed)
        }
    }

    /**
     * Updates ChessPiece.kingAttackers
     * Note: It isn't possible to have both side to be check because you must "uncheck" first
     */
    public void GetKingAttackers()
    {
        ChessPiece.kingAttackers.Clear();
        foreach (ChessPiece element in listOfChessPieces)
        {
            List<Vector2Int> possibleMoves = element.GeneratePossibleMoves();
            if (element.isBlack == true)
            {
                if (possibleMoves.Contains(whiteKing.location))
                {
                    isWhiteKingInCheck = true;
                    isBlackKingInCheck = false;
                    ChessPiece.kingAttackers.Add(element);
                }
            }
            else if (element.isBlack == false)
            {
                if (possibleMoves.Contains(blackKing.location))
                {
                    isBlackKingInCheck = true;
                    isWhiteKingInCheck = false;
                    ChessPiece.kingAttackers.Add(element);
                }
            }
        }
        if(ChessPiece.kingAttackers.Count == 0)
        {
            isWhiteKingInCheck = false;
            isBlackKingInCheck = false;
        }

    }

    public void IsGameOver()
    {
        if (whiteKing.GetPossibleMoves() == null) return;
        if (blackKing.GetPossibleMoves() == null) return;
        // Checks if black wins
        if (whiteKing.GetPossibleMoves().Count == 0)
        {
            //if (isWhiteKingInCheck) { gameOver = true; return; }
            foreach(ChessPiece element in listOfChessPieces)
            {
                if(element.GetPossibleMoves() == null) { continue; }
                if(!element.isBlack && element.GetPossibleMoves().Count > 0)
                {
                    if(element == whiteKing) { continue; }
                    gameOver = false;
                    return;
                }
            }
            gameOver = true;
            return;
        }
        else if(blackKing.GetPossibleMoves().Count == 0)
        {
            //if (isBlackKingInCheck) { gameOver = true; return; }
            foreach (ChessPiece element in listOfChessPieces)
            {
                if (element.GetPossibleMoves() == null) { continue; }
                if (element.isBlack && element.GetPossibleMoves().Count > 0)
                {
                    if(element == blackKing) { continue; }
                    gameOver = false;
                    return;
                }
            }
            gameOver = true;
            return;
        }
    }

    //-----------------------------------------------------------------------
    // Methods below are for initializing Variables
    // Most likely only used once
    //-----------------------------------------------------------------------

    /**
    * Creates an 2D array from a single list
    * */
    private void InitiateSelectionBoardHelper()
    {
        selectionBoardHelper = new GameObject[8, 8];
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                selectionBoardHelper[row, col] = selectionBoard[row + 8 * col];
            }
        }
    }

    /**
    * Creates an 2D array of color from a single list
    * This list is necessary to avoid calling GetComponent() every frame
    * */
    private void InitiateSelectionBoardColorArray()
    {
        selectionBoardColorArray = new ColorChanger[8, 8];
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                selectionBoardColorArray[row, col] = selectionBoard[row + 8 * col].GetComponent<ColorChanger>();
            }
        }
    }

    private void InitiateAndFillChessPieces(List<ChessPiece> cp)
    {
        listOfChessPieces = cp;
        chessPieces = new ChessPiece[8, 8];
        foreach (ChessPiece element in cp)
        {
            chessPieces[element.location.x, element.location.y] = element;
        }
    }

    private void InitializePiecesToReference()
    {
        foreach(ChessPiece element in listOfChessPieces)
        {
            element.SetChessBoard(this);
        }
    }

    public void UpdateBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                chessPieces[col, row] = null;
            }
        }
        foreach (ChessPiece element in listOfChessPieces)
        {
            chessPieces[element.location.x, element.location.y] = element;
        }
    }

    public void FindKings()
    {
        foreach (ChessPiece element in listOfChessPieces)
        {
            if (element.GetType() == typeof(King))
            {
                if (element.isBlack)
                {
                    blackKing = element;
                }
                else
                {
                    whiteKing = element;
                }
            }
        }
        if (blackKing == null)
        {
            Debug.Log("Missing black king");
        }
        if (whiteKing == null)
        {
            Debug.Log("Missing white king");
        }
    }


    //-----------------------------------------------------------------------
    // Methods below are for displaying the selection squares
    //-----------------------------------------------------------------------

    public void DisplayPossibleMoveFromSelectedPiece(ChessPiece selectedPiece)
    {
        if (selectedPiece != null)
        {
            List<Vector2Int> possibleMoves = selectedPiece.GetPossibleMoves();

            SetTileToGreenAt(selectedPiece.location);
            if (possibleMoves == null) return;
            foreach (Vector2Int element in possibleMoves)
            {
                // Sets the color of SelectionBoard
                if(chessPieces[element.x,element.y] == null)
                {
                    SetTileToBlueAt(element);
                }
                else if(chessPieces[element.x,element.y] == selectedPiece)
                {
                    Debug.Log(selectedPiece.location);
                    Debug.Log(element.x.ToString() + element.y.ToString());
                    Debug.Log("Bug");
                }
                else
                {
                    SetTileToRedAt(element);
                }
            }
        }
    }
    public void DisplayKingInCheck()
    {
        if(isBlackKingInCheck)
        {
            SetTileToRedAt(blackKing.location);
        }
        if(isWhiteKingInCheck)
        {
            SetTileToRedAt(whiteKing.location);
        }
    }


    /**
    * Deactivates all the SelectionBoard elements.
    * */
    public void ClearSelectionBoard()
    {
        foreach (GameObject element in selectionBoard)
        {
            if (element.activeSelf)
            {
                element.SetActive(false);
            }
        }
    }

    public void DeactivateTileAt(Vector2Int v)
    {
        if (selectionBoardHelper[v.x, v.y].activeSelf == true)
            selectionBoardHelper[v.x, v.y].SetActive(false);
    }

    /**
    * Sets the the selected Vector to the Yellow
    * */
    public void SetTileToYellowAt(Vector2Int v)
    {
        if (!selectionBoardColorArray[v.x, v.y].GetColor().Equals("Yellow"))
        {
            selectionBoardColorArray[v.x, v.y].SetToYellow();
        }
        if (selectionBoardHelper[v.x, v.y].activeSelf == false)
        {
            selectionBoardHelper[v.x, v.y].SetActive(true);
        }
    }

    /**
    * Sets the the selected Vector to the Blue
    * */
    public void SetTileToBlueAt(Vector2Int v)
    {
        if (!selectionBoardColorArray[v.x, v.y].GetColor().Equals("Blue"))
        {
            selectionBoardColorArray[v.x, v.y].SetToBlue();
        }
        if (selectionBoardHelper[v.x, v.y].activeSelf == false)
        {
            selectionBoardHelper[v.x, v.y].SetActive(true);
        }
    }

    /**
    * Sets the the selected Vector to the Green
    * */
    public void SetTileToGreenAt(Vector2Int v)
    {
        if (!selectionBoardColorArray[v.x, v.y].GetColor().Equals("Green"))
        {
            selectionBoardColorArray[v.x, v.y].SetToGreen();
        }
        if (selectionBoardHelper[v.x, v.y].activeSelf == false)
        {
            selectionBoardHelper[v.x, v.y].SetActive(true);
        }
    }
    public void SetTileToRedAt(Vector2Int v)
    {
        if (!selectionBoardColorArray[v.x, v.y].GetColor().Equals("Red"))
        {
            selectionBoardColorArray[v.x, v.y].SetToRed();
        }
        if (selectionBoardHelper[v.x, v.y].activeSelf == false)
        {
            selectionBoardHelper[v.x, v.y].SetActive(true);
        }
    }


}
