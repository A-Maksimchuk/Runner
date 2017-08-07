using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public abstract class ObjectsRow<T> : MonoBehaviour
    {

        protected float rowCount = 3;
        List<GameObject> objects;

        public void SetRowCount(int rowCount)
        {
            this.rowCount = rowCount;
        }

        //Добавляет новый объект в ряд 
        //При успешном добавлении возвращает true , 
        //если объект не подходит или ряд заполнен возвращает false и уничтожает объект
        public bool AddObject(GameObject g)
        {
            if (objects == null)
                objects = new List<GameObject>();

            if (g == null)
                return false;
            //Проверяем принадлежит ли переданный объект нужному типу
            if (g.GetComponent<T>() == null)
            {
                Destroy(g);
                return false;
            }
            //Проверка на свободные места в ряду
            if (objects.Count >= rowCount)
            {
                Debug.Log("Нет свободных мест в ряду " + objects.Count + " " + rowCount);
                 //Destroy(g);
                return false;
            }
            //Назначаем ряд родителем переданному объекту и выравниваем его позицию
            
            Transform t = g.transform;
            t.SetParent(transform);
            t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y, 0);
            objects.Add(g);
            return true;
        }

        public bool HasObjectOnPosition(Vector3 v)
        {
            return objects.Find(g => g.transform.localPosition == v) != null;
        }
    }
}