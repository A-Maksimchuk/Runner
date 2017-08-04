using UnityEngine;
using System.Collections;
using System;

public class Cleaner : MonoBehaviour {

    public Action onClean;

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Obstencle")
        {
            onClean.Invoke();
        }
    }
}
