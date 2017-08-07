using UnityEngine;
using System.Collections;

namespace Runner
{
    public class Obstencle : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameState.Instance.SetCurentState(GameState.State.GameOver);
            }
        }


    }
}
