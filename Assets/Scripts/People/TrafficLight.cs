using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] stopTrafficsPeople;
    public GameObject[] stopTrafficsCar;
    public float stopSecondsPeople;
    public float stopSecondsCar;
    bool entranceTraffic=true;
    // Update is called once per frame
    void Update()
    {
        if (entranceTraffic==true)
        {
            StartCoroutine(Traffic());
        }
    }
    IEnumerator Traffic()
    {
        entranceTraffic = false;
        for (int i = 0; i < stopTrafficsPeople.Length; i++)
        {
            stopTrafficsPeople[i].SetActive(true);
        }
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < stopTrafficsCar.Length; i++)
        {
            stopTrafficsCar[i].SetActive(false);
        }
        yield return new WaitForSeconds(stopSecondsPeople);
        for (int i = 0; i < stopTrafficsCar.Length; i++)
        {
            stopTrafficsCar[i].SetActive(true);
        }
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < stopTrafficsPeople.Length; i++)
        {
            stopTrafficsPeople[i].SetActive(false);
        }
        yield return new WaitForSeconds(stopSecondsCar);
        entranceTraffic = true;
    }
}
