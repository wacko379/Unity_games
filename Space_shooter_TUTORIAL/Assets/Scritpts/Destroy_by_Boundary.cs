using UnityEngine;
using System.Collections;

public class Destroy_by_Boundary : MonoBehaviour 
{
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}
