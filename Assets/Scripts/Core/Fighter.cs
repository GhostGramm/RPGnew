using RPG.Managers;
using System.Collections;
using UnityEngine;

namespace RPG.Core
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        private Transform target;

        private Mover entityMover;
        private ActionScheduler Scheduler;

        private void Start()
        {
            entityMover = GetComponent<Mover>();
            Scheduler= GetComponent<ActionScheduler>();
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
            Scheduler.StartAction(this);
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