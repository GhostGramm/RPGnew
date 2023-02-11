using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Ray lastRay;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<NavMeshAgent>().destination = target.position;
        DrawRay();
    }

    void DrawRay()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        Debug.DrawLine(lastRay.origin, lastRay.direction * 100, Color.green);
    }
}
