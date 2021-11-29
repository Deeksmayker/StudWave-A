using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveCar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform startPoint;
    [SerializeField] Transform finalPoint;
    [SerializeField] Transform[] trafficStop;
    [SerializeField] Transform distanceCar;
    public GameObject distanceCarActive;
    public GameObject[] trafficActive;
    private float progress;
    private float distanceTraveled;
    public float speed;
    private void FixedUpdate()
    {
        if (gameObject.activeSelf)
        {
            TrafficCar();
        }
        ReturnToStartPoint();
    }

    private void ReturnToStartPoint()
    {
        if (transform.position == finalPoint.position)
        {
            progress -= distanceTraveled;
            distanceTraveled = 0;
            gameObject.SetActive(false);
        }
    }

    private void TrafficCar()
    {
        bool carMovement = true;
        for (int i = 0; i < trafficStop.Length; i++)
        {
            if (ComparisonCarPandTrafficLightP(i))
            {
                carMovement = false;
            }
        }
        carMovement = KeepingDistance(carMovement);
        if (carMovement == true)
        {
            CarMovement();
        }
    }
    private bool ComparisonCarPandTrafficLightP(int i)
    {
        return transform.position.x > trafficStop[i].position.x - trafficStop[i].localScale.x / 2 &&
                        transform.position.x < trafficStop[i].position.x + trafficStop[i].localScale.x / 2 &&
                        transform.position.z > trafficStop[i].position.z - trafficStop[i].localScale.z / 2 &&
                        transform.position.z < trafficStop[i].position.z + trafficStop[i].localScale.z / 2 &&
                        trafficActive[i].activeSelf;
    }

    private bool KeepingDistance(bool carMovement)
    {
        if (ComparisonCarPositions())
        {
            carMovement = false;
        }

        return carMovement;
    }

    private bool ComparisonCarPositions()
    {
        return transform.position.x > distanceCar.position.x - distanceCar.localScale.x * 2 &&
                transform.position.x < distanceCar.position.x + distanceCar.localScale.x * 2 &&
                transform.position.z > distanceCar.position.z - distanceCar.localScale.z / 2 &&
                transform.position.z < distanceCar.position.z + distanceCar.localScale.z / 2 && distanceCarActive.activeSelf;
    }

    private void CarMovement()
    {
        transform.position = Vector3.Lerp(startPoint.position, finalPoint.position, progress);
        progress += speed;
        distanceTraveled += speed;
    }
}   

