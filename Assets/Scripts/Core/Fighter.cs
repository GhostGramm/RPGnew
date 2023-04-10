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
        private Health target;

        private Mover entityMover;
        private Animator animator;
        private ActionScheduler Scheduler;
        private float timeSinceLastAttack;

        private void Start()
        {
            entityMover = GetComponent<Mover>();
            animator = GetComponent<Animator>();
            Scheduler= GetComponent<ActionScheduler>();
        }
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null)   return;  
            if(target.IsDead()) return;

            if (!GetIsInRange())
            {
                entityMover.MoveTo(target.transform.position);
            }
            else
            {
                entityMover.Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform.position);


            if (timeSinceLastAttack > timeBetweenAttack)
            {
                //triggers the Hit() Animation Event
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        void TriggerAttack()
        {
            animator.ResetTrigger("stopAttack");
            animator.SetTrigger("attack");
        }

        void stopAttack()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("stopAttack");
        }

        //animation event
        void Hit()
        {
            ApplyDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            Scheduler.StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void ResetTarget(CombatTarget combatTarget = null)
        {
            if(combatTarget== null)
            {
                target = null;
            }
            else
            {
                target = combatTarget.GetComponent<Health>();
            }
        }

        public void ApplyDamage(float damage)
        {
            if (target == null) return;

            target.TakeDamage(damage);
        }

        public bool canAttack(CombatTarget target)
        {
            if (target == null) return false;

            Health targetHealth = target.GetComponent<Health>();

            return targetHealth != null && !targetHealth.IsDead();

        }

        public void Cancel()
        {
            stopAttack();
            ResetTarget(null);
        }
    }
}