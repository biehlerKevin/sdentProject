using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int lives = 20;
    public int money = 100;

    public Text moneyText;
    public Text livesText;

    public void LoseLife(int l = 1)
    {
        lives -= l;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        //TODO: Send Player to a game over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        //TODO: This doesn't actually need to update the text every frame
        moneyText.text = "Money: $" + money.ToString();
        livesText.text = "Lives:  " + lives.ToString();
    }

}
