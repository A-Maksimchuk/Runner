using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour {

    public GameObject pausePanel;

	public void ActivatePausePanel()
    {
        if (!GameState.Instance.IsGameOverState())
        {
            pausePanel.SetActive(true);
            GameState.Instance.SetCurentState(GameState.State.Pause);
        }
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        GameState.Instance.SetCurentState(GameState.State.Play);
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
            ActivatePausePanel();
    }

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
            ActivatePausePanel();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
