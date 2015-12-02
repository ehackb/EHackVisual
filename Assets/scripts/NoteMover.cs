using UnityEngine;
using System.Collections;

public class NoteMover : MonoBehaviour {

	private Rigidbody body;

	void Start () 
	{	
		body = GetComponent<Rigidbody>();
	}

	void Update () 
	{
		float x = transform.position.x + Random.Range(0.01f ,0.05f);
		float y = transform.position.y + Random.Range(-0.02f ,0.02f);
		float z = transform.position.z;

		Vector3 moveTo = new Vector3 (x, y, z);
		
		body.MovePosition(moveTo);
	}
}
