using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollisionWithBigMesh : MonoBehaviour
{
    //[SerializeField]SkinnedMeshRenderer meshRenderer;
    //[SerializeField] MeshCollider collider;

    public float m_updateDelay=2f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touch !", collision.gameObject);
        Debug.DrawLine(collision.contacts[0].point, collision.contacts[0].point+Vector3.up*50, Color.red, 60);
        TryToUnpool(collision.gameObject);
    }

    private void TryToUnpool(GameObject gameObject)
    {
        PoolObject obj = gameObject.GetComponent<PoolObject>();
        if (obj == null)
            obj = gameObject.GetComponentInParent<PoolObject>();
        if (obj != null)
            obj.SetAsActive(false);
    }

    //public IEnumerator Start()
    //{
    //    while (true) {
    //        yield return new WaitForEndOfFrame();
    //        yield return new WaitForSeconds(m_updateDelay);
    //        UpdateCollider();
    //    }

    //}
    //public void UpdateCollider()
    //{
    //    Mesh colliderMesh = new Mesh();
    //    meshRenderer.BakeMesh(colliderMesh);
    //    collider.sharedMesh = null;
    //    collider.sharedMesh = colliderMesh;
    //}
}
