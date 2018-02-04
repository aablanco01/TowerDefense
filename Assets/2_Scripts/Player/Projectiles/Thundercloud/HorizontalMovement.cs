using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public int MoveSpeed = 0;
    public float MinMovement, MaxMovement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlatform();	
	}

    public void MovePlatform()
    {
        transform.Translate(Input.GetAxis("Mouse X") * Time.deltaTime * MoveSpeed, 0, 0);
    }

    void LimitXMovement()
    {

    }
}
