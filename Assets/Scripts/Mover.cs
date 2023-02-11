using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private NavMeshAgent PlayerNav;
    private Ray lastRay;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        PlayerNav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MoveToPoint();
        }
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
}
