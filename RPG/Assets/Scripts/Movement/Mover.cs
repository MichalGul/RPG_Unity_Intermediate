using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    Ray lastRay;
    private NavMeshAgent navMesh;

 

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor(Input.mousePosition);

        }

        UpdateAnimator();
        
    }

    void MoveToCursor(Vector3 targetPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(targetPosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            navMesh.destination = hit.point;
        }

    }

    private void UpdateAnimator()
    {
        //! Parse navmesh velocity to animator blend tree to adjust animation speed of player
        Vector3 velocity = navMesh.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); //change global velocity to local
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed); //change parameter in animator parameters to change animation in blend tree

    }

}
