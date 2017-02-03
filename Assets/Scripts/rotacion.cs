using UnityEngine;
using System.Collections;

public class rotacion : MonoBehaviour {
	private float x;
	void Start () {
		//transform.Rotate(0, x, 0);
	}

	void FixedUpdate(){
		transform.Rotate(0, x, 0);
		x += 0.01f;
	}
}
