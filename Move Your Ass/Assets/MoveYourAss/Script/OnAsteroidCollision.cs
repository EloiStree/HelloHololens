using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAsteroidCollision : MonoBehaviour
{
    public OnAsteroidHitEvent m_collisionWithAsteroid;

    private void OnCollisionEnter(Collision collision)
    {
     AsteroidTag  asteroid =   collision.rigidbody.gameObject.GetComponent<AsteroidTag>();
        m_collisionWithAsteroid.Invoke(asteroid,collision);
    }

    [System.Serializable]
    public class OnAsteroidHitEvent: UnityEvent<AsteroidTag, Collision> { }
}
