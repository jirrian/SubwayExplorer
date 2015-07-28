using UnityEngine;
using System.Collections;

public class stationSwitch : MonoBehaviour {
	public GameObject fade;
	public AudioSource sound;
//	bool canEnter;
	void Start(){
	//	canEnter = false;
		fade = GameObject.FindWithTag("fade");
	}

	void Update(){
		if(transform.parent.gameObject.GetComponent<trainController>().speed <= 0){
			GetComponent<Renderer>().enabled = true;
		}
		else{
			GetComponent<Renderer>().enabled = false;
		}

	/*	if(Input.GetKey(KeyCode.Space)){
			canEnter = true;
		}
		else{
			canEnter = false;
		}
		Debug.Log(canEnter);
	*/
	}

	void OnTriggerEnter(Collider player){
		// sets flag to change station
		if(player.tag == "Player" && transform.parent.gameObject.GetComponent<trainController>().speed <= 0 /* && canEnter*/){
				if(transform.parent.gameObject.GetComponent<trainController>().positive == true){
					player.GetComponent<gameLogic>().change = 10;
				}
				else{
					player.GetComponent<gameLogic>().change = 11;
				}
				sound.Play();
				fade.gameObject.GetComponent<fadeToBlack>().beginFade();
				player.transform.position = new Vector3(0f, 2.5f, 0.2f);
		}
	}
}
