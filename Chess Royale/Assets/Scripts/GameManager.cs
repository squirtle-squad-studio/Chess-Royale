using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState { check4Check, selectPiece1, getPossibleMove, selectPiece2, move, nextPlayer};

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
        foreach(GameObject cube in selectionBoard)
        {
            cube.SetActive(false);
        }
        selectionBoard[cursor.x + 8 * cursor.y].SetActive(true);
        selectionBoard[cursor.x + 8 * cursor.y].GetComponent<ColorChanger>().SetToYellow();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePicture();
        GetInput();
        UpdateState();
    }

    private void UpdatePicture()
    {
        //Testing Displays possible move from the given selected piece
        if (selectedPiece != null)
        {
            Debug.Log("Location"+selectedPiece.location);
            List<Vector2Int> possibleMove = selectedPiece.GetPossibleMoves();
            foreach (Vector2Int element in possibleMove)
            {
                Debug.Log("PossibleMove"+element);
                // This doesn't seem that efficient because it keeps setting true and changing color every frame
                selectionBoard[element.x + 8 * element.y].SetActive(true);
                selectionBoard[element.x + 8 * element.y].GetComponent<ColorChanger>().SetToBlue();
            }
            selectionBoard[selectedPiece.location.x + 8 * selectedPiece.location.y].SetActive(true);
            selectionBoard[selectedPiece.location.x + 8 * selectedPiece.location.y].GetComponent<ColorChanger>().SetToGreen();
        }

        //if(cursor != prevCursor)
        //{
            selectionBoard[prevCursor.x + 8 * prevCursor.y].SetActive(false);
            selectionBoard[cursor.x + 8 * cursor.y].SetActive(true);
            selectionBoard[cursor.x + 8 * cursor.y].GetComponent<ColorChanger>().SetToYellow();
        //}
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
                //Debug.Log("Return pressed");
                selectedPiece.Move(cursor);
                ClearBoard();
            }
        }
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            ClearBoard();
            selectionBoard[cursor.x + 8 * cursor.y].SetActive(true);
            selectionBoard[cursor.x + 8 * cursor.y].GetComponent<ColorChanger>().SetToYellow();
            selectedPiece = null; // TEST
        }
    }
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

    private void ClearBoard()
    {
        foreach(GameObject element in selectionBoard)
        {
            element.SetActive(false);
        }
    }
}
