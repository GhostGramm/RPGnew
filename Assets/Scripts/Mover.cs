using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        if(Input.GetMouseButtonDown(0))
        {
            MoveToPoint();
            
        }

        UpdateAnimatorSpeed();
    }

    void MoveToPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isValid = Physics.Raycast(ray, out hit);

        if (isValid)
        {
            PlayerNav.destination = hit.point;
        }
    }

    void UpdateAnimatorSpeed()
    {
        Vector3 velocity = PlayerNav.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;

        PlayerAnimator.SetFloat("Forward", speed);
        Debug.Log($"{velocity} {localVelocity}");
    }
}
