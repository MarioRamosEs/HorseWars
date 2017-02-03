using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;
	public int depth = -20;

	// Update is called once per frame
	void Update()
	{
		if(player != null){
			//transform.position = new Vector3(playerTransform.position.x-10, playerTransform.position.y, playerTransform.position.z-10);
			//transform.rotation = playerTransform.rotation;
			transform.parent = player;
		}
	}

	public void setTarget(Transform target){
		player = target;
		transform.position = new Vector3(0,2,-5);
		transform.rotation = Quaternion.Euler(new Vector3(7,0,0));
	}
}