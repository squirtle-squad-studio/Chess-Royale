using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text gameOver; // Not implemented yet
    public Text check;

    void Start()
    {
        gameOver.gameObject.SetActive(false);
        check.gameObject.SetActive(false);
    }

    public void WhiteKingInCheck()
    {
        check.text = "White is in check";
        check.gameObject.SetActive(true);
    }

    public void BlackKingInCheck()
    {
        check.text = "Black is in check";
        check.gameObject.SetActive(true);
    }

    public void DeactivateText()
    {
        check.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
    }
}
