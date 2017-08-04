using UnityEngine;
using System.Collections;

public class RoadPice : MonoBehaviour {

    private SpeedController sc;

    public void Start()
    {
        sc = FindObjectOfType<SpeedController>();
    }

	void Update () {
        if(GameState.Instance.IsCurentState(GameState.State.Play))
        transform.position += new Vector3(0, 0, -sc.GetCurentSpeed() * Time.deltaTime);
    }
}
