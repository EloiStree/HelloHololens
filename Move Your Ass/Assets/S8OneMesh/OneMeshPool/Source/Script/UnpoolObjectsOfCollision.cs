using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoolObjectsOfCollision : MonoBehaviour
{
    public void Unpool(GameObject detector, Collider collision) {
        PoolObject.TryToUnpool(detector);
        PoolObject.TryToUnpool(collision.gameObject);
    }
}
