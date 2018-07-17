using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private Text gemsText;
    [SerializeField] private Text restartText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text gameWonText;
        
    private bool gameOver, gameWon, restart;
    private int goldScore, gemsScore;
    
	// Use this for initialization
	void Start ()
	{
	    gameOverText.text = "";
	    restartText.gameObject.SetActive(false);
	    gameWonText.gameObject.SetActive(false); 
	    gameOver = false;
	    gameWon = false;
	    restart = false;
	    goldScore = 0;
	    gemsScore = 0;
	    UpdateGoldCoins();
	    UpdateGems();
	}
	
	// Update is called once per frame
	void Update () {
	    if (restart)
	    {
	        if (Input.GetKeyDown(KeyCode.R))
	        {
	            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	        }
	    }
	}

    public void AddScore(string type)
    {
        switch (type)
        {
            case "Coin":
                goldScore += 10;
                UpdateGoldCoins();
                break;
            
            case "Gem":
                gemsScore++;
                UpdateGems();
                break;
        }
    }

    void UpdateGoldCoins()  
    {
        // Update the score text
        scoreText.text = "Gold Coins: " + goldScore.ToString();
    }

    void UpdateGems()
    {
        // Update the gems count text
        gemsText.text = "Gems: " + gemsScore.ToString() + "/4";
        if (gemsScore == 4)
        {
            gameWon = true;
            gameWonText.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
            restart = true;
        }
    }
}
