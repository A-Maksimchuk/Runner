using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private enum StayPoints { Left =-3, Right=3, Center=0}
    private StayPoints stay;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight();
    }

	public void MoveLeft()
    {
        if (GameState.Instance.IsCurentState(GameState.State.Play))
            switch (stay)
        {
            case StayPoints.Right:
                {
                    stay = StayPoints.Center;
                    break;
                }
            case StayPoints.Center:
                {
                    stay = StayPoints.Left;
                    break;
                }
            case StayPoints.Left:
                {
                    return;
                }
        }
        Move();
    }

    public void MoveRight()
    {
        if(GameState.Instance.IsCurentState(GameState.State.Play))
        switch (stay)
        {
            case StayPoints.Right:
                {
                    return;
                }
            case StayPoints.Center:
                {
                    stay = StayPoints.Right;
                    break;
                }
            case StayPoints.Left:
                {
                    stay = StayPoints.Center;
                    break;
                }
        }
        Move();
    }

    private void Move()
    {

        transform.position = new Vector3((int)stay, transform.position.y, transform.position.z);
       
    }
}
