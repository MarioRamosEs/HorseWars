using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public int velocidad, impulse;
	private Rigidbody rigidbody;

	//public GameObject CameraJugador;
	//private Camera cj;
	//private Camera cm;

	public override void OnStartLocalPlayer(){
		Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
	}

	void Start(){
		/*if (!isLocalPlayer) return;
		//cm = CameraMenu.GetComponent<Camera>();
		cj = CameraJugador.GetComponent<Camera>();
		cj.enabled = true;
		//cm.enabled = false;*/
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (!isLocalPlayer) return;

		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f*velocidad/2;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f*velocidad;
		rigidbody.AddTorque(0,x*10,0);
		rigidbody.AddForce(transform.forward * z * impulse);
		//transform.Rotate(0, x, 0);
		//transform.Translate(0, 0, z);

		//playerCamera.transform.position = transform.position + offset;

		if (Input.GetKeyDown(KeyCode.Space)) CmdFire();
		
	}

	// This [Command] code is called on the Client …
	// … but it is run on the Server!
	[Command]
	void CmdFire(){
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward*13*velocidad;

		// Spawn the bullet on the Clients
		NetworkServer.Spawn(bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
}