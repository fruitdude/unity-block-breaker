using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minScreenWidthInUnitsX = 0f;
    [SerializeField] float maxScreenWidthInUnitsX = 16f;

    //cache reference
    Ball theBall;
    GameSession gameSession;

    void Start(){
        gameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    void Update(){
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minScreenWidthInUnitsX, maxScreenWidthInUnitsX);
        transform.position = paddlePosition;
    }

    private float GetXPos() {
        if (gameSession.IsAutoPlayEnabled()) {
            return theBall.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
