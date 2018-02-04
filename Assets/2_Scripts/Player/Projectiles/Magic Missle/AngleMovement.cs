using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float MinRotation;
    public float MaxRotation;

    private bool MaxReached, MinReached;


    // Use this for initialization
    void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveCannon();
        //limitRotation();
    }



    void MoveCannon()
    {
        transform.Rotate(0, 0, Input.GetAxis("Mouse Y") * Time.deltaTime * MoveSpeed);
    }

    void LimitRotation()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, MinRotation, MaxRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);

        //Come back to this!
    }
}
