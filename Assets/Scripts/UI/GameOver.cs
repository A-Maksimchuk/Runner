using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverPanel;

    

    void Start () {
        GameState.Instance.ListenState(GameState.State.GameOver,OnGameOver);
	}
	
	void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
