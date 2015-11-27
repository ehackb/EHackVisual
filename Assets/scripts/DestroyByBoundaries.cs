using UnityEngine;
using System.Collections;

public class DestroyByBoundaries : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
