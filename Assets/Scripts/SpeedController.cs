using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeedController : MonoBehaviour {

    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float speedUp = 30;
    private float tempSpeedUp = 0;
    public GameObject gameOverPanel;

    void Start()
    {
        tempSpeedUp = speedUp;
    }

	void Update () {
        if (GameState.Instance.IsPlayState())
        {
            tempSpeedUp -= Time.deltaTime;
            if (tempSpeedUp <= 0)
            {
                speed++;
                tempSpeedUp = speedUp;
            }
        }
	}

    public float GetCurentSpeed()
    {
        return speed;
    }
}
