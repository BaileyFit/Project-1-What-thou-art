using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {
	
	public Transform target;

	void Update () 
	{
		if (target)
		{
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
		
	}
