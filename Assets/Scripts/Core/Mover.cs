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

        void SetUp()
        {
            PlayerNav = GetComponent<NavMeshAgent>();
            PlayerAnimator = GetComponent<Animator>();
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

        public void MoveTo(Vector3 point)
        {
            PlayerNav.destination = point;
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

