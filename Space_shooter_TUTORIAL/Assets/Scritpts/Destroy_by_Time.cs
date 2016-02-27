using UnityEngine;
using System.Collections;

public class Destroy_by_Time : MonoBehaviour 
{
	public float lifetime;
	void Start()
	{
		Destroy(gameObject, lifetime);
	}
}
