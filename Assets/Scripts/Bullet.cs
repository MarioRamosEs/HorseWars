using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	void OnTriggerEnter(Collider other){
		Debug.Log ("Impacto");

		var hit = other.gameObject;
		var health = hit.GetComponent<Health>();
		if (health != null) health.TakeDamage(10);
		Destroy(gameObject);
	}
}