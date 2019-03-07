using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateOnClickDown : MonoBehaviour
{
    public GameObject toDuplicate;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            GameObject obj =    GameObject.Instantiate(toDuplicate);
            obj.SetActive(true);
        }
        
    }
}
