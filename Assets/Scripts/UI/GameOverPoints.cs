using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Runner;

public class GameOverPoints : MonoBehaviour {

	
	void Start () {
        GetComponent<Text>().text = string.Format("{0:D8}", (int)FindObjectOfType<GameManager>().GetTotalPoints());
	}
	
	
}
