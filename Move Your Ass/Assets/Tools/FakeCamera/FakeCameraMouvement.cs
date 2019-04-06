using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCameraMouvement : MonoBehaviour
{
    public Transform m_affected;
    public Vector3 m_speed = Vector3.one;

    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.Keypad6)) direction.x += 1f;
        if (Input.GetKey(KeyCode.Keypad4)) direction.x -= 1f;
        if (Input.GetKey(KeyCode.Keypad8)) direction.y += 1f;
        if (Input.GetKey(KeyCode.Keypad5)) direction.y -= 1f;
        if (Input.GetKey(KeyCode.Keypad7)) direction.z += 1f;
        if (Input.GetKey(KeyCode.Keypad1)) direction.z -= 1f;
        m_affected.Translate(Time.deltaTime * Mutiply(m_speed, direction), Space.Self);
    }

    private Vector3 Mutiply(Vector3 speed, Vector3 direction)
    {
        direction.x *= speed.x;
        direction.y *= speed.y;
        direction.z *= speed.z;
        return direction;

    }

    private void Reset()
    {
        m_affected = transform;
    }
}
