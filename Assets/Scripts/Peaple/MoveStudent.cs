using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveStudent : MonoBehaviour
{
    [SerializeField] NavMeshAgent[] arrayAgent;
    [SerializeField] Transform uniPoint;
    [SerializeField] Transform homePoint;
    public GameObject[] students; 
    bool flagStopping=true;
    int countStudent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Approximately(uniPoint.position.x, students[countStudent].transform.position.x)&&
            Mathf.Approximately(uniPoint.position.z, students[countStudent].transform.position.z) &&
            flagStopping==true)
        {
            flagStopping = false;
            Invoke("GotoHome", 3);
        }
        if (Mathf.Approximately(homePoint.position.x, students[countStudent].transform.position.x) &&
            Mathf.Approximately(homePoint.position.z, students[countStudent].transform.position.z) &&
            flagStopping == true)
        {
            flagStopping = false;
            Invoke("GotoUni", 3);
        }
    }
    void GotoHome()
    {
        students[countStudent].SetActive(true);
        arrayAgent[countStudent].SetDestination(homePoint.position);
        countStudent++;
        if (countStudent > students.Length)
        {
            Invoke("Stopping", 10);
        }
        else
        {
            flagStopping = true;
        }
    }
    void GotoUni()
    {
        students[countStudent].SetActive(true);
        arrayAgent[countStudent].SetDestination(uniPoint.position);
        countStudent++;
        if (countStudent >= students.Length)
        {
            Invoke("Stopping", 10);
        }
        else
        {
            flagStopping = true;
        }
    }
    void Stopping()
    {
        flagStopping = true;
        countStudent = 0;
    }
}
