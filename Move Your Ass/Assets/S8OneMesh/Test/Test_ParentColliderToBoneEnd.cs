using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Test_ParentColliderToBoneEnd : MonoBehaviour
{
    public List<ViewLinkedToMesh> m_bonesViewToCollider;
    [Header("Dirty edit")]
    public List<Transform> m_bones;
    public List<Transform> m_bonesCollider;
    public bool m_linkToParent;
    [System.Serializable]
    public struct ViewLinkedToMesh
    {
        public Transform view;
        public Transform collider;

    }

    private void OnValidate()
    {
        if (m_bones.Count > 0 && m_bonesCollider.Count > 0) {

            //int minCount = m_bones.Count < m_bonesCollider.Count? 
            //    m_bones.Count-1 :
            //    m_bonesCollider.Count-1;

            for (int i = 0; i < m_bones.Count; i++)
            {
                ViewLinkedToMesh link = new ViewLinkedToMesh() { view = m_bones[i], collider = FindNearest(m_bones[i]) };
                m_bonesViewToCollider.Add(link);
            }
            m_bones.Clear();
            m_bonesCollider.Clear();
        }

        if (m_linkToParent) {
            m_linkToParent = false;
            for (int i = 0; i < m_bonesViewToCollider.Count; i++)
            {
                m_bonesViewToCollider[i].collider.parent =
                m_bonesViewToCollider[i].view;
            }
        }

    }
    public Transform FindNearest(Transform theBone) {
      return  m_bonesCollider.OrderBy(t => Vector3.Distance(t.position, theBone.position)).First();
    }
}
