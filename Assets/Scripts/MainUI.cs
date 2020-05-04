using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerType
{
    player,
    AI
}
public class MainUI : MonoBehaviour
{
    private int _playerScoreInt;
    private int _aiScoreInt;
    public Text playerScore;
    public Text aiScore;
    public static MainUI Instace; 
    private void Start()
    {
        if (Instace == null)
        {
            Instace = this;
        }else if (Instace != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.player:
                _playerScoreInt++;
                playerScore.text = _playerScoreInt.ToString();
                break;
            case PlayerType.AI:
                _aiScoreInt++;
                aiScore.text = _aiScoreInt.ToString();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(playerType), playerType, null);
        }
    }
}
