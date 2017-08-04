using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {

    [SerializeField]
    private Cleaner cleanerBody;

    public GameObject roadPicePref;
    private Queue<GameObject> roadPices = new Queue<GameObject>();
    public int partRoadPassed { get; private set; }
    

    void Start () {
        partRoadPassed = 0;
        cleanerBody.onClean = AddNewRoadPice;
        for (int i = 0; i < 5; i++)
        {

            GameObject g = Instantiate(roadPicePref, new Vector3(0, 0, 40 * i), Quaternion.identity) as GameObject;
            roadPices.Enqueue(g);
            if (i > 0)
                g.GetComponent<ObstencleGenerator>().Init();
        }
    }
	
	void AddNewRoadPice()
    {
        partRoadPassed++;
        Destroy(roadPices.Dequeue());
        GameObject g = Instantiate(roadPicePref, new Vector3(0, 0, 160+roadPices.Peek().transform.position.z), Quaternion.identity) as GameObject;
        roadPices.Enqueue(g);
        g.GetComponent<ObstencleGenerator>().Init();
    }
}
