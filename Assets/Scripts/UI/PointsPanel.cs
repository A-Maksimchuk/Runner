using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsPanel : MonoBehaviour {

    Text txt;
    
    void Start()
    {
        txt = GetComponent<Text>();
    }
     
    public void PointUp(int totalPoints)
    {
        txt.text = string.Format("{0:D8}", totalPoints);
    }
    
}
