using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{

    public class PatrolPath : MonoBehaviour
    {
            [SerializeField] float waypointSphereRadius = 1;


            private void OnDrawGizmos()
            {

                for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(GetWaypoint(i), waypointSphereRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
            }




        }

        public int GetNextIndex(int i)
        {
            if (i + 1 == transform.childCount)
            {
                return 0; 
            }
            else
            {
                return i + 1;

            }
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
