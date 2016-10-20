using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public Text highestScore;
    public Text currentScore;
    public GameObject player;
        
    // Use this for initialization
    void Start () {
        if (player == null)
            player = GameObject.FindWithTag("Player");
		
		int previousHighestScore = PlayerPrefs.GetInt("highestScore");
		highestScore.text = "Highest Score: " + previousHighestScore;
    }
	
	// Update is called once per frame
	void Update () {
        currentScore.text = "Current Score: " + (int)player.transform.position.x;
        if ((int) player.transform.position.x > int.Parse(highestScore.text.Substring(14))) {
            highestScore.text = "Highest Score: " + (int)player.transform.position.x;
        }         
    }
}
