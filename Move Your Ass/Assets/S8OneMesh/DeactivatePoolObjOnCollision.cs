using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePoolObjOnCollision : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("Hummm ?");
        if (collision.gameObject.tag == "Cylon") {
            PoolObject bullet = collision.gameObject.GetComponent<PoolObject>();
            bullet.SetAsActive(false);
         //   Debug.Log("Boum !");
        }
    }
}
