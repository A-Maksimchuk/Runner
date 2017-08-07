using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class PlayerController : MonoBehaviour, Moveble
    {
        private int roadwaysCount = 3;
        private int curentRoad = 0;

        public void InitPlayer(int roadwaysCount)
        {
            this.roadwaysCount = roadwaysCount;
        }

        public void Move()
        {
            transform.localPosition = new Vector3(-(((roadwaysCount * 3) / 2) - 1.5f) + 3 * curentRoad, transform.localRotation.y, transform.localPosition.z);
        }

        public void MoveLeft()
        {
            if (curentRoad > 0)
                curentRoad--;
            Move();
        }

        public void MoveRight()
        {
            if (curentRoad < roadwaysCount-1)
                curentRoad++;
            Move();
        }

        // Use this for initialization
        void Start()
        {
            Move();
        }

        
    }
}
