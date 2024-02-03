using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerManager : MonoBehaviour
{
    private Vector3 targetPosition;
    //public float maxAccel = 20f;
    //public float maxVel = 5f;
    //public float decelDistance = 2f;

    public float pValue = .1f;
    public float currVelDamp = 1f;

    private Vector3 currVel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVel = targetPosition - transform.position;
        currVel += targetVel * pValue * Time.deltaTime - currVel * currVelDamp * Time.deltaTime;
        transform.position += currVel * Time.deltaTime;
    }

    public void SetTargetPos(Vector3 newPos)
    {
        targetPosition = newPos;
    }
}
