using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testOverlap : MonoBehaviour
{
    void Update()
    {
        //Collider2D col;
        List<Collider2D> colliders = new List<Collider2D>();
        if (Input.GetKeyDown(KeyCode.E))
        {
            ContactFilter2D filter = new ContactFilter2D();
            Physics2D.OverlapPoint(Input.mousePosition, filter.NoFilter(), colliders);

            foreach (var item in colliders)
            {
                Debug.Log(item.name);
            }

            if (colliders.Count == 0)
            {
                Debug.Log("0");
            }
            //if (col == null)
            //{
            //    Debug.Log("null");
            //}
            //else
            //{
            //    Debug.Log("not null");
            //}
            Debug.Log("Done");
        }
    }
}