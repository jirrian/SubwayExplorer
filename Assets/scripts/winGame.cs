using UnityEngine;
using System.Collections;

public class winGame : MonoBehaviour {

	public GameObject fade;
	void Start(){
		fade = GameObject.FindWithTag("fade");
	}

	void OnTriggerEnter(Collider player){
		// sets flag to change station

		// end of game graphics
		if(player.tag == "Player"){
			fade.gameObject.GetComponent<fadeToBlack>().beginFade();
			player.GetComponent<gameLogic>().station = 0;
		}
	}
}
