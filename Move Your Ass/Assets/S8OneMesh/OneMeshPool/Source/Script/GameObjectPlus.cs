using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPlus : MonoBehaviour
{

    public void SetActive(bool value) {
        gameObject.SetActive(value);
    }
    public void AutoDestroy()
    {
        Destroy(this);
    }
}
