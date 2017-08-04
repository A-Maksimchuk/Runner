using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour {
    
    [SerializeField]
    private SpeedController _speedController;
    [SerializeField]
    private RoadGenerator _roadGenerator;
    [SerializeField]
    private PointsPanel _pointsPanel;

    private float _totalPoints;
    private float _playTime;

    private void Awake()
    {
        GameState.Instance.Clear();
        GameState.Instance.SetCurentState(GameState.State.Play);
        GameState.Instance.ListenState(GameState.State.GameOver, OnGameOver);
    }

    void Update () {
        if (GameState.Instance.IsPlayState())
        {
            _totalPoints += _speedController.GetCurentSpeed() / 5 * Time.deltaTime;
            _playTime += Time.deltaTime;
            _pointsPanel.PointUp((int)_totalPoints);
        }
	}

    [ContextMenu("AutoFill")]
    void AutoFill()
    {
        _speedController = FindObjectOfType<SpeedController>();
        _roadGenerator = FindObjectOfType<RoadGenerator>();
        _pointsPanel = FindObjectOfType<PointsPanel>();
    }

    public float GetTotalPoints()
    {
        return _totalPoints;
    }

    void OnGameOver()
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic.Add("Play Time", _playTime);
        dic.Add("Total Points", _totalPoints);
        dic.Add("Part road passed", _roadGenerator.partRoadPassed);
        Analytics.CustomEvent("GameOver", dic);
    }
}
