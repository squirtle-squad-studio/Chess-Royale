using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState { check4Check, selectPiece1, getPossibleMove, selectPiece2, move, nextPlayer}; // Currently unused

    // Game State
    GameState state;
    public List<GameObject> selectionBoard; // This is a single list taken from a 8x8 board. Advice: please use the helper variable, it's easier.
    private GameObject[,] selectionBoardHelper; // selectionBoard but in 2D array
    private ColorChanger[,] selectionBoardColorArray; // selectionBoard but in 2D array

    public Horse horse; // Testing 
    private bool waitForInput;
    private bool check;

    // User Input
    private Vector2Int prevCursor; // Where the cursor was before
    private Vector2Int cursor; // Location where cursor is
    private ChessPiece selectedPiece;


    // Start is called before the first frame update
    void Start()
    {
        bool check = false;
        waitForInput = false;
        cursor = new Vector2Int(0,0);
        state = GameState.check4Check;

        InitiateSelectionBoardHelper();
        InitiateSelectionBoardColorArray();

        // Disables all selection cubes in selectionBoard except the starting one
        ClearSelectionBoard();
        SetSelectionBoardToYellow(cursor);
    }

    // Update is called once per frame
    void Update()
    {
        GraphicsUpdate();
        GetInput();
        UpdateState();
    }

    private void GraphicsUpdate()
    {
        DisplayPossibleMoveFromSelectedPiece();
        RemovePreviousCursor();
        SetSelectionBoardToYellow(cursor);

        prevCursor = cursor; // Updates the prevCursor
    }


    private void GetInput() {
        if(Input.GetKeyUp(KeyCode.W))
        {
            if(cursor.y - 1 >= 0 && cursor.y - 1 < 8)
            {
                cursor.y -= 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (cursor.x - 1 >= 0 && cursor.x - 1 < 8)
            {
                cursor.x -= 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (cursor.y + 1 >= 0 && cursor.y + 1 < 8)
            {
                cursor.y += 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (cursor.x + 1 >= 0 && cursor.x + 1 < 8)
            {
                cursor.x += 1;
            }
        }
        if (Input.GetKey(KeyCode.Return))
        {
            // testing purpose
            // Checks if cursor selects a valid piece
            if(cursor == horse.location)
            {
                selectedPiece = horse;
            }
            if(selectedPiece != null)
            {
                selectedPiece.Move(cursor);
                ClearSelectionBoard();
            }
        }
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            ClearSelectionBoard();
            SetSelectionBoardToYellow(cursor);
            selectedPiece = null;
        }
    }

    /**
     * Planned to use this as game logic
     * */
    private void UpdateState()
    {
        // Testing Moving piece

        // Will probably use this when we are able to move pieces around
        if (waitForInput)
        {
            return;
        }
        else {
            switch (state)
            {
                case GameState.check4Check:
                    break;
                case GameState.selectPiece1:
                    break;
                case GameState.getPossibleMove:
                    break;
                case GameState.selectPiece2:
                    break;
                case GameState.move:
                    break;
                case GameState.nextPlayer:
                    break;
                default:
                    Debug.Log("Default switch case reached.");
                    break;
            }
        }
    }
    private bool isCheck() { return false; }
    private List<Vector2> SelectPiece() { return null; }
    private void NextPlayer() { }

    private void DisplayPossibleMoveFromSelectedPiece()
    {
        if (selectedPiece != null)
        {
            List<Vector2Int> possibleMove = selectedPiece.GetPossibleMoves();
            foreach (Vector2Int element in possibleMove)
            {
                SetSelectionBoardToBlue(element);
            }
            SetSelectionBoardToGreen(selectedPiece.location);
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
     * Deactivates all the SelectionBoard elements.
     * */
    private void ClearSelectionBoard()
    {
        foreach(GameObject element in selectionBoard)
        {
            element.SetActive(false);
        }
    }

    /**
     * Deactivates the previous cursor to prevent trails as the cursor moves
     * */
    private void RemovePreviousCursor()
    {
        if(selectionBoardHelper[prevCursor.x , prevCursor.y].activeSelf == true)
            selectionBoardHelper[prevCursor.x, prevCursor.y].SetActive(false);
    }

    /**
     * Sets the the selected Vector to the Yellow
     * */
    private void SetSelectionBoardToYellow(Vector2Int v)
    {
        selectionBoardHelper[v.x, v.y].SetActive(true);
        selectionBoardColorArray[v.x, v.y].SetToYellow();
    }

    /**
    * Sets the the selected Vector to the Blue
    * */
    private void SetSelectionBoardToBlue(Vector2Int v)
    {
        selectionBoardHelper[v.x , v.y].SetActive(true);
        selectionBoardColorArray[v.x, v.y].SetToBlue();
    }

    /**
    * Sets the the selected Vector to the Green
    * */
    private void SetSelectionBoardToGreen(Vector2Int v)
    {
        selectionBoardHelper[v.x , v.y].SetActive(true);
        selectionBoardColorArray[v.x, v.y].SetToGreen();
    }
}
