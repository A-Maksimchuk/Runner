using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

namespace Runner
{
    public class Road : MonoBehaviour
    {
        

        [SerializeField]
        public RoadGenerator roadGenerator;

        [Tooltip("Настройки генерации препятствий на дороге")]
        [SerializeField]
        public ObstencleGenerator obstencleGenerator;

        private const int minRoadways = 3;

        private void Start()
        {
            transform.localScale = new Vector3(roadGenerator.roadwaysCount / (float)minRoadways, transform.localScale.y, transform.localScale.z);
            GenerateRoad();
        }

        private void OnValidate()
        {
            if (enabled)
            {
                //Изменение ширины дороги в соответствии с количеством полос движения
                transform.localScale = new Vector3(roadGenerator.roadwaysCount / (float)minRoadways, transform.localScale.y, transform.localScale.z);
            }
        }
       
        [Button]
        private void GenerateRoad()
        {
            if (roadGenerator.conteiner != null)
                DestroyRoad();
                obstencleGenerator.GenerateObstencle(roadGenerator.GenerateStartRoads(), roadGenerator.roadwaysCount, roadGenerator.partLength);
        }

        [Button]
        private void DestroyRoad()
        {
            if (roadGenerator.conteiner != null)
                DestroyImmediate(roadGenerator.conteiner);
        }
    }

    
}
