﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard
{
    private List<GameObject> selectionBoard;
    private List<ChessPiece> listOfChessPieces; // Actual Chess Pieces
    private ChessPiece[,] chessPieces; // Same as listOfChessPieces but with Location of where the pieces are

    private GameObject[,] selectionBoardHelper; // selectionBoard but in 2D array
    private ColorChanger[,] selectionBoardColorArray; // selectionBoard but in 2D array

    public ChessBoard(List<GameObject> mySelectionBoard, List<ChessPiece> cp)
    {
        selectionBoard = mySelectionBoard;
        InitiateSelectionBoardHelper();
        InitiateSelectionBoardColorArray();
        InitiateAndFillChessPieces(cp);
    }

    public ChessPiece GetPiece(Vector2Int v)
    {
        UpdateBoard();
        return chessPieces[v.x, v.y];
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

    private void UpdateBoard()
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



    //-----------------------------------------------------------------------
    // Methods below are for displaying the selection squares
    //-----------------------------------------------------------------------

    public void DisplayPossibleMoveFromSelectedPiece(ChessPiece selectedPiece)
    {
        if (selectedPiece != null)
        {
            // List<Vector2Int> possibleMoves = GeneratePossibleMoves(selectedPiece);
            List<Vector2Int> possibleMoves = selectedPiece.GeneratePossibleMoves(this);
            foreach (Vector2Int element in possibleMoves)
            {
                // Sets the color of SelectionBoard
                if(chessPieces[element.x,element.y] == null)
                {
                    SetTileToBlueAt(element);
                }
                else
                {
                    // So far any pieces will be red, but in the future we should not include friendly meaning
                    SetTileToRedAt(element);
                }
            }
            SetTileToGreenAt(selectedPiece.location);
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
