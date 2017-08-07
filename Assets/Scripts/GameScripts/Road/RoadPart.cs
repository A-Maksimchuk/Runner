using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class RoadPart : MonoBehaviour
    {

        private int length = 0;
        private int rowCount = 0;
        private List<ObstenclesRow> obstenclesRows;

        

        public void SetLength(int length)
        {
            this.length = length;
        }

        public void SetRowCount(int rowCount)
        {
            this.rowCount = rowCount;
        }

        public void SetObstencle(Obstencle[,] obstencles)
        {
            obstenclesRows = new List<ObstenclesRow>();
            if (obstencles.Length < length)
                Debug.LogError("Длинна массива не соответствует длинне участка дороги.");

            for(int i = 0; i < obstencles.GetLength(0); i++)
            {
                GameObject g = new GameObject();
                g.transform.SetParent(transform);
                g.name = "Row";
                ObstenclesRow obstencleRow = g.AddComponent<ObstenclesRow>();
                obstencleRow.SetRowCount(rowCount);
                obstencleRow.transform.localPosition = new Vector3(0, 0, i * 8);
                for (int n=0; n < obstencles.GetLength(1); n++)
                {
                    if (obstencles[i, n] != null)
                    {
                        obstencleRow.AddObject(obstencles[i, n].gameObject);
                    }
                }
                obstenclesRows.Add(obstencleRow);
                
            }
        }

        private void Update()
        {
            if(GameState.Instance.IsPlayState())
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - GameManager.Instance.curentSpeed * Time.deltaTime);
            if(length > 0)
            if (transform.localPosition.z < -(length * 8 + 8)) {
                //TODO: пофиксить
                FindObjectOfType<Road>().roadGenerator.AddNewRoad();
            }
        }
    }
}
