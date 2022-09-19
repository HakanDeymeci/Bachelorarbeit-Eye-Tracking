using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Pathfollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 10;
    float distanceTraveled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetDirectionAtDistance(distanceTraveled);
    }
}
