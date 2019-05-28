using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;

namespace RPG.Control
{


    public class AIController : MonoBehaviour
    {
    
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;

        private void Start() 
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindGameObjectWithTag("Player");
        }


        private void Update() 
        {
            if (InAttackRangeOffPlayer() && fighter.CanAttack(player))
            {
                GetComponent<Fighter>().Attack(player);
            }
            else
            {
                fighter.Cancel();
            }

        }
        private bool InAttackRangeOffPlayer()
        {
            return Vector3.Distance(transform.position, player.transform.position) < chaseDistance;
        }


    }

}