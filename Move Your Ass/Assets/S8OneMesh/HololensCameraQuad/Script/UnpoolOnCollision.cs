using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoolOnCollision : MonoBehaviour
{
    //public LayerMask m_condition;
    public void OnCollisionEnter(Collision collision)
    {

        CheckIfUnpoolable(collision.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        CheckIfUnpoolable(other.gameObject);
    }

    private void CheckIfUnpoolable(GameObject col)
    {
        PoolObjectInterface poolable = col.GetComponent<PoolObjectInterface>();
        if (poolable != null)
            poolable.SetAsActive(false);
    }
}
