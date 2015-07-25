using UnityEngine;
using System.Collections;

public class cameraRotation : MonoBehaviour {
	public Camera myCamera;

	float hRotate;
	float vRotate;
	public float hSpeed = 3f;	// speed of rotation horizontally
	public float vSpeed = 3f;	// speed of rotation vertically

	public float minRotate = -50f;
	public float maxRotate = 50f;
	// Update is called once per frame
	void Update () {

		// adjust camera rotation to mouse location
		hRotate = hSpeed * Input.GetAxis("Mouse X");
		vRotate -= vSpeed * Input.GetAxis("Mouse Y");

		// clamp y-look
		vRotate = Mathf.Clamp(vRotate, minRotate, maxRotate);

		transform.Rotate(0f, hRotate, 0f);
		myCamera.transform.localEulerAngles = new Vector3(vRotate, 0f, 0f);
	
	}
}
