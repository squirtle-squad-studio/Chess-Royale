using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        name = "Queen";
        for(int i = -7; i < 8; i++)
        {
            moves.Add(new Vector2Int(i, i));
            moves.Add(new Vector2Int(-i, i));
            moves.Add(new Vector2Int(0, i));
            moves.Add(new Vector2Int(0, -i));
            moves.Add(new Vector2Int(-i, 0));
            moves.Add(new Vector2Int(i, 0));
        }



    }
    public override List<Vector2Int> GeneratePossibleMoves(ChessBoard cb)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int guess = new Vector2Int();

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x + i;
            guess.y = location.y + i;

            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }

            possibleMoves.Add(guess);

            if (cb.GetPiece(guess) != null)
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x - i;
            guess.y = location.y + i;

            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }

            possibleMoves.Add(guess);

            if (cb.GetPiece(guess) != null)
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x - i;
            guess.y = location.y - i;

            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }

            possibleMoves.Add(guess);

            if (cb.GetPiece(guess) != null)
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x + i;
            guess.y = location.y - i;

            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }

            possibleMoves.Add(guess);

            if (cb.GetPiece(guess) != null)
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x - i;
            guess.y = location.y;
            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }
            possibleMoves.Add(guess);
            if (cb.GetPiece(guess) != null)
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x + i;
            guess.y = location.y;
            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }
            possibleMoves.Add(guess);
            if (cb.GetPiece(guess) != null)
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x;
            guess.y = location.y - i;
            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }
            possibleMoves.Add(guess);
            if (cb.GetPiece(guess) != null)
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            guess.x = location.x;
            guess.y = location.y + i;
            if (guess.x < 0 || guess.y < 0 || guess.x > 7 || guess.y > 7)
            {
                break;
            }
            possibleMoves.Add(guess);
            if (cb.GetPiece(guess) != null)
            {
                break;
            }
        }
        return possibleMoves;
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
