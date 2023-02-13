using System.Collections;
using UnityEngine;

namespace RPG.Core
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        private Transform target;

        private Mover entityMover;

        private void Start()
        {
            entityMover = GetComponent<Mover>();
        }
        private void Update()
        {
            if (target != null)
            {
               entityMover.MoveTo(target.position);

                float rangeDistance = Vector3.Distance(transform.position, target.position);
                if (rangeDistance < weaponRange)
                {
                    entityMover.StopMovement();
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}