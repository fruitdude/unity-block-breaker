using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour{

    // config params
    [Range(0.1f, 10.0f)] [SerializeField] float gameSpeed = 1.0f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int pointsPerBlockDestroyed = 50;
    [SerializeField] bool isAutoPlayEnabled;
    

    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length; //gives us the number of GameStatus objects
        if(gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);  
        }
    }

    private void Start() {
        updateScoreUI();
    }


    // Update is called once per frame
    void Update(){
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        currentScore += pointsPerBlockDestroyed;
        updateScoreUI();
    }

    public void updateScoreUI() {
        scoreText.text = currentScore.ToString();
    }

    public void resetScore() {
        currentScore = 0;
        updateScoreUI();
    }

    public bool IsAutoPlayEnabled() {
        return isAutoPlayEnabled;
    }
}
