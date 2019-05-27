using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{


    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        private bool isDead = false;

        public bool IsDead() => isDead;


        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            Debug.Log(healthPoints);
            if (healthPoints == 0)
            {
                
                TriggerDeath();
            }

        }

        public void TriggerDeath()
        {
            if (!isDead)
            {
                GetComponent<Animator>().SetTrigger("die");
                isDead = true;
            }
        }



    }

}
