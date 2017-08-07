using System;
using System.Collections.Generic;


public class GameState: Singleton<GameState> {

    public enum State { Pause, GameOver, Play}
    private List<Action> pauseListeners;
    private List<Action> playListeners;
    private List<Action> gameOverListeners;

    private State _curentState;
	
    private GameState()
    {
        _curentState = State.Play;
        pauseListeners = new List<Action>();
        playListeners = new List<Action>();
        gameOverListeners = new List<Action>();
    }

    public void Clear()
    {
        pauseListeners.Clear();
        playListeners.Clear();
        gameOverListeners.Clear();
    }

    public State GetCurentState()
    {
        return _curentState;
    }

    public bool IsCurentState(State state)
    {
        return state == _curentState;
    }

    public void SetCurentState(State state)
    {
        _curentState = state;
        switch (_curentState)
        {
            case State.Play:
                {
                    DoActions(playListeners);
                    break;
                }
            case State.Pause:
                {
                    DoActions(pauseListeners);
                    break;
                }
            case State.GameOver:
                {
                    DoActions(gameOverListeners);
                    break;
                }
        }
    }

    public bool IsPlayState()
    {
        return _curentState == State.Play;
    }

    public bool IsPauseState()
    {
        return _curentState == State.Pause;
    }

    public bool IsGameOverState()
    {
        return _curentState == State.GameOver;
    }

    public void ListenState(State state, Action action)
    {
        switch (state)
        {
            case State.Play:
                {
                    playListeners.Add(action);
                    break;
                }
            case State.Pause:
                {
                    pauseListeners.Add(action);
                    break;
                }
            case State.GameOver:
                {
                    gameOverListeners.Add(action);
                    break;
                }
        }
    }

    void DoActions(List<Action> actionList)
    {
        for(int i=0; i<actionList.Count; i++)
        {
            actionList[i].Invoke();
        }
    }
}
