using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class GameManager : Singleton<GameManager>
    {
        [Tooltip("Стартовая скорость движения.")]
        public float startSpeed;
        [Tooltip("Величина на которую увеличивается скорость за шаг.")]
        public float speedUp;
        [Tooltip("Количество очков по достижению которого увеличивается скорость.")]
        public float speedUpBorder;
        [Tooltip("Количество очков выдаваемых в секунду за единицу скорости.")]
        public float pointPerSpeed;
        [SerializeField]
        private PointsPanel pointsPanel;

        public float curentSpeed{ get; private set; }
        private float curentPoints;
        private float borderPoint;

        private void Awake()
        {
            GameState.Instance.SetCurentState(GameState.State.Play);
            curentSpeed = startSpeed;
            borderPoint = 0;
            //TODO: пофиксить
            FindObjectOfType<PlayerController>().InitPlayer(FindObjectOfType<Road>().roadGenerator.roadwaysCount);
        }

        private void Update()
        {
            float pointUp = pointPerSpeed * curentSpeed * Time.deltaTime;
            curentPoints += pointUp;
            borderPoint += pointUp;
            if (borderPoint >= speedUpBorder)
            {
                borderPoint = 0;
                curentSpeed += speedUp;
            }
            pointsPanel.PointUp((int)curentPoints);
        }

        public float GetTotalPoints()
        {
            return curentPoints;
        }
    }
}