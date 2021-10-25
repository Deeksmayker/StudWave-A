using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePeaple : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform[] arrayPointWalk;
    float x;
    float z;
    int countPoint=0;

    bool b=true;
    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
    }

    void Update()
    {
        if (Mathf.Approximately(x, transform.position.x)&&
            Mathf.Approximately(z, transform.position.z)&& countPoint < arrayPointWalk.Length && b==true)
        {
            b = false;
            agent.SetDestination(arrayPointWalk[countPoint].position);
            countPoint++;
        }
        else if (countPoint >= arrayPointWalk.Length)
        {
            countPoint = 0;
            b = true;
        }
        else
        {
            x = transform.position.x;
            z = transform.position.z;
            Debug.Log("2");
            b = true;
        }
    }

}
