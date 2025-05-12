using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public ballmove ball;
    public Text playescore;
    public Text computerscore;
    private int playerscore;

    private int comscore;

    public void PlayerScoreAdd()
    {
        playerscore++;
        playescore.text = playerscore.ToString();
        ball.resetpos();
    }

    public void ComScoreAdd()
    {
        comscore++;
        computerscore.text = comscore.ToString();
        ball.resetpos();
    }
}
