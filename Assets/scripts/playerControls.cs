using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {

	public float speed = 325f;

	float hRotate;
	public float hSpeed = 3f;
	public float minRotate = -50f;
	public float maxRotate = 50f;

	float playerY, playerZ;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		Rigidbody rbody = GetComponent<Rigidbody>();

		//side stepping
		rbody.AddRelativeForce(x * speed * Time.deltaTime, 0f, y * speed * Time.deltaTime, ForceMode.VelocityChange);
	}

	void Update(){
		// simulate infinitely long space
		playerY = transform.position.y;
		playerZ = transform.position.z;
		if(transform.position.x >= 11.38f){
			transform.position = new Vector3(-11.48f, playerY, playerZ);
		}
		else if(transform.position.x <= -11.48f){
			transform.position = new Vector3(11.38f, playerY, playerZ);
		}
	}
}
