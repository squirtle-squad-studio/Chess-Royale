using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState { check4Check, selectPiece1, getPossibleMove, selectPiece2, move, nextPlayer};

    private bool waitForInput;
    public List<GameObject> selectionBoard;
    private bool check;
    private Vector2Int cursor;
    private ChessPiece selectedPiece;
    GameState state;


    // Start is called before the first frame update
    void Start()
    {
        bool check = false;
        waitForInput = false;
        cursor = new Vector2Int(0,0);
        state = GameState.check4Check;

        foreach(GameObject cube in selectionBoard)
        {
            cube.SetActive(false);
        }
        selectionBoard[cursor.x + 8 * cursor.y].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePicture();
        getInput();
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

    private void UpdatePicture()
    {
        selectionBoard[cursor.x + 8 * cursor.y].SetActive(true);
    }
    private void getInput() {
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
    }
    private bool isCheck() { return false; }
    private List<Vector2> SelectPiece() { return null; }
    private void NextPlayer() { }
}
