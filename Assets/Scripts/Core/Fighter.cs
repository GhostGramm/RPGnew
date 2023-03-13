using RPG.Managers;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.Core
{
    public class Fighter : MonoBehaviour, iAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 2f;
        [SerializeField] float timeBetweenAttack = 1f;
        private Transform target;

        private Mover entityMover;
        private Animator PlayerAnimator;
        private ActionScheduler Scheduler;
        private float timeSinceLastAttack;

        private void Start()
        {
            entityMover = GetComponent<Mover>();
            PlayerAnimator = GetComponent<Animator>();
            Scheduler= GetComponent<ActionScheduler>();
        }
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetIsInRange())
            {
                entityMover.MoveTo(target.position);
            }
            else
            {
                entityMover.Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if(timeSinceLastAttack > timeBetweenAttack)
            {
                //triggers the Hit() Animation Event
                PlayerAnimator.SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        //animation event
        void Hit()
        {
            ApplyDamage(weaponDamage);
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

        public void ApplyDamage(float damage)
        {
            if (target == null) return;

            target.GetComponent<Health>().TakeDamage(damage);
        }

        public void Cancel()
        {
            ResetTarget(null);
        }
    }
}