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
            if (target == null) return;

            if (!GetIsInRange())
            {
                entityMover.MoveTo(target.position);
            }
            else
            {
                entityMover.StopMovement();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void ResetTarget(CombatTarget combatTarget = null)
        {
            if(combatTarget== null)
            {
                target = null;
            }
            else
            {
                target = combatTarget.transform;
            }
        }
    }
}