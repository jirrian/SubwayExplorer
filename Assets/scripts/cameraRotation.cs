using UnityEngine;
using System.Collections;

public class cameraRotation : MonoBehaviour {
	float hRotate;
	float vRotate;
	public float hSpeed = 3f;	// speed of rotation horizontally
	public float vSpeed = 3f;	// speed of rotation vertically

	public float minRotate = -50f;
	public float maxRotate = 50f;
	// Update is called once per frame
	void Update () {

		// adjust camera rotation to mouse location
		// adapted from Unity documentation
		hRotate -= hSpeed * Input.GetAxis("Mouse X");
		vRotate -= vSpeed * Input.GetAxis("Mouse Y");

		hRotate = Mathf.Clamp(hRotate, minRotate, maxRotate);
		vRotate = Mathf.Clamp(vRotate, minRotate, maxRotate);

		transform.localRotation = Quaternion.Euler(vRotate, hRotate, 0);
	
	}
}
