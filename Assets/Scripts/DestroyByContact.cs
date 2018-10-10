using System;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public GameObject AsteroidExplosion;
	public GameObject PlayerExplosion;
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Boundary")) return;
		Destroy(other.gameObject);
		Destroy(gameObject);
		Instantiate(AsteroidExplosion, transform.position, transform.rotation);
		Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
	}
}
