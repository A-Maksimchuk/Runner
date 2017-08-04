using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstencleGenerator : MonoBehaviour
{

    public int density;
    public GameObject[] obstenclePrefs;
    
    private List<Vector3> spawnPoints;



    public void Init()
    {
        spawnPoints = new List<Vector3>();
            
        for (int z = -2; z <= 30; z += 8) {
            for (int x = 3; x >= -3; x-=3) {
                 spawnPoints.Add(new Vector3(transform.position.x+x,0,transform.position.z+z));
            }
        }
        

        if (density > spawnPoints.Count)
            density = 5;
        Vector3[] tempSpawns;
        Vector3 spawnPoint;
        int spawnNum;
        for (int i = 0; i < density; i++)
        {
            spawnNum = Random.Range(0, spawnPoints.Count);
            spawnPoint = spawnPoints[spawnNum];

            tempSpawns = spawnPoints.FindAll(n => n.z == spawnPoints[spawnNum].z).ToArray();
            if (tempSpawns.Length < 3)
            {
                for (int n = 0; n < tempSpawns.Length; n++)
                {
                    spawnPoints.Remove(tempSpawns[n]);
                }
            }
            else
            {
                spawnPoints.Remove(spawnPoint);
            }

            GameObject g = Instantiate(obstenclePrefs[Random.Range(0, obstenclePrefs.Length)], spawnPoint, Quaternion.identity);
            g.transform.SetParent(transform);
        }
    }


}
