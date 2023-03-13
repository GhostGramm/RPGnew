using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float TotalHealth;

        private Boolean isDead = false;

        public void TakeDamage(float damage)
        {
            TotalHealth = Mathf.Max(TotalHealth - damage, 0);
            if(TotalHealth == 0)
            {
                Die();
            }
        }

        public void Die()
        {
            if (isDead) return;
            
            isDead= true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}

