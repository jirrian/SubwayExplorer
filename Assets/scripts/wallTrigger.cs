using UnityEngine;
using System.Collections;

public class wallTrigger : MonoBehaviour {
	public GameObject otherTrigger;
	public float offset;	// so player does not spawn on trigger
	Vector3 newPos;

	void OnTriggerEnter(Collider player){
		// simulates infinite platform
		if(player.tag == "Player"){	// only changes position of player (not trains)
			newPos = new Vector3(otherTrigger.transform.position.x + offset, player.transform.position.y, player.transform.position.z);
			player.transform.position = newPos;
		}
	}
}
