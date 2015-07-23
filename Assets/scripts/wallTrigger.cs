using UnityEngine;
using System.Collections;

public class wallTrigger : MonoBehaviour {
	public GameObject otherTrigger;
	public float offset;
	Vector3 newPos;

	void OnTriggerEnter(Collider player){

		newPos = new Vector3(otherTrigger.transform.position.x + offset, player.transform.position.y, player.transform.position.z);
	
		player.transform.position = newPos;

	}
}
