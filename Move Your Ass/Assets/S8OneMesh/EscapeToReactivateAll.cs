using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EscapeToReactivateAll : MonoBehaviour {

	IEnumerator Start () {
        while (true)
        {
            yield return new WaitForSeconds(20);
            foreach (PoolObject obj in FindObjectsOfType<PoolObject>().Where(x => x.gameObject.tag == "Cylon").ToList())
            {
                obj.SetAsActive(true);
            } 
        }
	}
	void Update () {
		
	}
}
