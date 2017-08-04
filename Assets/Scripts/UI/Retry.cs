using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

	public void RetryButt()
    {
        SceneManager.LoadScene(0);
    }

}
