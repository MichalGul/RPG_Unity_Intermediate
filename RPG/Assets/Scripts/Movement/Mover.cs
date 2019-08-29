using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;


namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] public Transform target;
        [SerializeField] float maxSpeed = 6f;
        Health health;
        NavMeshAgent navMehs;

        Ray lastRay;


        private void Start()
        {
            navMehs = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }

        void Update()
        {
            navMehs.enabled = !health.IsDead();
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction);
        }


        public void MoveTo(Vector3 destination, float speedFraction)
        {
            navMehs.destination = destination;
            navMehs.speed = Mathf.Clamp01(speedFraction) * maxSpeed;
            navMehs.isStopped = false;
        }

        public void Cancel()
        {
            navMehs.isStopped = true;
        }


        private void UpdateAnimator()
        {
            //! Parse navmesh velocity to animator blend tree to adjust animation speed of player
            Vector3 velocity = navMehs.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); //change global velocity to local
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed); //change parameter in animator parameters to change animation in blend tree

        }

    }
}
