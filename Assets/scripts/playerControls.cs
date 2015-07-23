using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {

	public float speed = 325f;
//	public float turnSpeed = 90f;

	float hRotate;
	public float hSpeed = 3f;
//	public float hSpeed = Camera.main.GetComponent.cameraRotation.hSpeed;	// speed of rotation horizontally
	public float minRotate = -50f;
	public float maxRotate = 50f;
//	public float minRotate = Camera.main.GetComponent.cameraRotation.minRotate;
//	public float maxRotate = Camera.main.GetComponent.cameraRotation.maxRotate;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		Rigidbody rbody = GetComponent<Rigidbody>();

		// forward and backward
	//	rbody.AddRelativeForce(0f, 0f, y * speed * Time.deltaTime);

		// rotation
		
	
//		float temp = Camera.main.transform.eulerAngles.y;
//		temp = Mathf.Clamp(temp, minRotate, maxRotate);
	//	transform.localRotation = Quaternion.Euler(0, temp, 0);
	

	/*	Vector3 playerRotation = Camera.main.transform.eulerAngles;
		playerRotation.x = 0;
		playerRotation.z = 0;
		playerRotation.y = Mathf.Clamp(playerRotation.y, -50f, 50f);
		Debug.Log(playerRotation);
		transform.localEulerAngles = playerRotation;
	*/
		//transform.Rotate(0f, x * turnSpeed * Time.deltaTime, 0f);

		//side stepping
		rbody.AddRelativeForce(x * speed * Time.deltaTime, 0f, y * speed * Time.deltaTime);
	}
}
