using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState { check4Check, selectPiece1, getPossibleMove, selectPiece2, move, nextPlayer}; // Currently unused

    // Game State
    GameState state;
    public List<GameObject> selectionBoard; // This is a single list taken from a 8x8 board
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
        //Testing Displays possible move from the given selected piece
        if (selectedPiece != null)
        {
            List<Vector2Int> possibleMove = selectedPiece.GetPossibleMoves();
            foreach (Vector2Int element in possibleMove)
            {
                // This doesn't seem that efficient because it keeps setting true and changing color every frame
                SetSelectionBoardToBlue(element);
            }
            SetSelectionBoardToGreen(selectedPiece.location);
        }
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
            selectedPiece = null; // TEST
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
        selectionBoard[prevCursor.x + 8 * prevCursor.y].SetActive(false);
    }

    /**
     * Sets the the selected Vector to the Yellow
     * */
    private void SetSelectionBoardToYellow(Vector2Int v)
    {
        selectionBoard[v.x + 8 * v.y].SetActive(true);
        selectionBoard[v.x + 8 * v.y].GetComponent<ColorChanger>().SetToYellow();
    }

    /**
    * Sets the the selected Vector to the Blue
    * */
    private void SetSelectionBoardToBlue(Vector2Int v)
    {
        selectionBoard[v.x + 8 * v.y].SetActive(true);
        selectionBoard[v.x + 8 * v.y].GetComponent<ColorChanger>().SetToBlue();
    }

    /**
    * Sets the the selected Vector to the Green
    * */
    private void SetSelectionBoardToGreen(Vector2Int v)
    {
        selectionBoard[v.x + 8 * v.y].SetActive(true);
        selectionBoard[v.x + 8 * v.y].GetComponent<ColorChanger>().SetToGreen();
    }
}
