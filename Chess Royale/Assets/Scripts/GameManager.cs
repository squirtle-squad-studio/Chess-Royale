using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState { check4Check, selectPiece1, getPossibleMove, selectPiece2, move, nextPlayer};

    private bool waitForInput;
    public int[,] board;
    private bool check;
    private Vector2 cursor;
    private ChessPiece selectedPiece;
    GameState state;

    // Start is called before the first frame update
    void Start()
    {
        board = new int[8,8];
        bool check = false;
        waitForInput = false;
        cursor = new Vector2(0,0);
        state = GameState.selectPiece1;
    }

    // Update is called once per frame
    void Update()
    {
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

    private void getInput() { }
    private bool isCheck() { return false; }
    private List<Vector2> SelectPiece() { return null; }
    private void NextPlayer() { }
}
