using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Runner
{
    [Serializable]
    public class ObstencleGenerator 
    {
        [Tooltip("Плотность генерируемых препятствий на дороге." +
            "\n 0 - перпятствий нет" +
            "\n 1 - препятствия встречаются довольно редко " +
            "\n 2 - средняя плотность препятствий " +
            "\n 3 - большая плотность препятствий")]
        [Range(0, 3)]
        public int dencity = 1;
        [Tooltip("Варианты препятствий")]
        public GameObject[] obstenclePrefs;

        public void GenerateObstencle(Queue<RoadPart> roadParts, int roadwaysCount, int length)
        {
            if (dencity > 0)
            {

                foreach (RoadPart rp in roadParts)
                {
                    Obstencle[,] obstencles = new Obstencle[length, roadwaysCount];
                    
                    for(int x = 0; x<length; x++)
                    {
                        int n = 0;
                        for (int y=0; y<roadwaysCount; y++)
                        {
                            if (UnityEngine.Random.Range(0, 3) < dencity)
                            {
                                int i = UnityEngine.Random.Range(0, roadwaysCount);
                                if (obstencles[x, i] == null)
                                {
                                    GameObject obst = GameObject.Instantiate(obstenclePrefs[UnityEngine.Random.Range(0, obstenclePrefs.Length)]);
                                    obst.transform.localPosition = new Vector3(-(((roadwaysCount*3)/2)-1.5f) + 3 * i, 0, 0);
                                    obstencles[x, i] = obst.GetComponent<Obstencle>();
                                    n++;
                                }
                                if (dencity == 1)
                                    break;
                                if (n == roadwaysCount - 1)
                                    break;
                            }
                        }
                    }
                    rp.SetObstencle(obstencles);
                }
            }
        }

        public void GenerateObstencle(RoadPart rp, int roadwaysCount, int length)
        {
            if (dencity > 0)
            {
                    Obstencle[,] obstencles = new Obstencle[length, roadwaysCount];

                    for (int x = 0; x < length; x++)
                    {
                        int n = 0;
                        for (int y = 0; y < roadwaysCount; y++)
                        {
                            if (UnityEngine.Random.Range(0, 3) < dencity)
                            {
                                int i = UnityEngine.Random.Range(0, roadwaysCount);
                                if (obstencles[x, i] == null)
                                {
                                    GameObject obst = GameObject.Instantiate(obstenclePrefs[UnityEngine.Random.Range(0, obstenclePrefs.Length)]);
                                    obst.transform.localPosition = new Vector3(-(((roadwaysCount * 3) / 2) - 1.5f) + 3 * i, 0, 0);
                                    obstencles[x, i] = obst.GetComponent<Obstencle>();
                                    n++;
                                }
                                if (dencity == 1)
                                    break;
                                if (n == roadwaysCount - 1)
                                    break;
                            }
                        }
                    }
                    rp.SetObstencle(obstencles);
                
            }
        }
    }
}
