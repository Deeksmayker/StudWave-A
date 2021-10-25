using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcealmentStudent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject student;
    [SerializeField] Transform uniPoint;
    [SerializeField] Transform homePoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Approximately(uniPoint.position.x, transform.position.x) &&
            Mathf.Approximately(uniPoint.position.z,transform.position.z) ||
            Mathf.Approximately(homePoint.position.x, transform.position.x) &&
            Mathf.Approximately(homePoint.position.z, transform.position.z))
        {
            student.SetActive(false);
        }
    }
}
