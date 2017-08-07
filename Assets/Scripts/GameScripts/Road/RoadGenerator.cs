using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Runner
{
    [Serializable]
    public class RoadGenerator 
    {
        [Tooltip("Префаб участка дороги")]
        public GameObject roadPartPref;
        [Tooltip("Протяженность одного участка, выраженная в количестве рядов препятствий")]
        public int partLength;
        [Tooltip("Длинна промежутка между участками с препятствиями, выраженная в количестве рядов препятствий")]
        public int partIntervalLength;
        [Tooltip("Количество полос на дороге.")]
        [Range(3, 7)]
        public int roadwaysCount = 3;
        [Tooltip("Отступ от начала трека до первой полосы препятствий, выраженная в количестве рядов препятствий")]
        public int startSpace = 3;

        private Queue<RoadPart> roadParts;
        public GameObject conteiner;

        public Queue<RoadPart> GenerateStartRoads()
        {

            if (conteiner != null)
            {
                return roadParts;
            }
            float _startSpace = startSpace * 8;
            conteiner = new GameObject();
            roadParts = new Queue<RoadPart>();
            GameObject road = GameObject.FindObjectOfType<Road>().gameObject;
            conteiner.transform.SetParent(road.transform);
            conteiner.name = "RoadConteiner";
            for (int i = 0; i < 5; i++)
            {
                GameObject roadPart = GameObject.Instantiate(roadPartPref, conteiner.transform);
                roadPart.transform.localPosition = new Vector3(0, 0,_startSpace+(i * 8 * partLength) + i * partIntervalLength*8);
                RoadPart rp = roadPart.AddComponent<RoadPart>();
                rp.SetRowCount(roadwaysCount);
                rp.SetLength(partLength);
                roadParts.Enqueue(rp);
            }
            
            return roadParts;


        }

        public void AddNewRoad()
        {
            GameObject.Destroy(roadParts.Dequeue().gameObject);
            GameObject roadPart = GameObject.Instantiate(roadPartPref, conteiner.transform);
            roadPart.transform.localPosition = new Vector3(0, 0, roadParts.Peek().transform.position.x + ( 4 * 8 * partLength) + 4 * partIntervalLength * 8);
            RoadPart rp = roadPart.AddComponent<RoadPart>();
            rp.SetRowCount(roadwaysCount);
            rp.SetLength(partLength);
            roadParts.Enqueue(rp);
            //TODO: пофиксить
            GameObject.FindObjectOfType<Road>().obstencleGenerator.GenerateObstencle(rp, roadwaysCount, partLength);
        }
    
    }

}