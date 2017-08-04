using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadingScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
