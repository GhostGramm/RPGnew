using RPG.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Core
{
    public class Mover : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private NavMeshAgent PlayerNav;
        private Animator PlayerAnimator;
        private ActionScheduler Scheduler;

        void SetUp()
        {
            PlayerNav = GetComponent<NavMeshAgent>();
            PlayerAnimator = GetComponent<Animator>();
            Scheduler= GetComponent<ActionScheduler>();
        }
        void Start()
        {
            SetUp();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimatorSpeed();
        }

        public void StartMovementAction(Vector3 point)
        {
            Scheduler.StartAction(this);

            GetComponent<Fighter>().ResetTarget();
            MoveTo(point);
        }

        public void MoveTo(Vector3 point)
        {
            PlayerNav.isStopped = false;
            PlayerNav.destination = point;
        }

        public void StopMovement()
        {
            PlayerNav.isStopped = true;
        }

        void UpdateAnimatorSpeed()
        {
            Vector3 velocity = PlayerNav.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            PlayerAnimator.SetFloat("Forward", speed);
        }
    }

}

