using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stationUI : MonoBehaviour {
	string text;
	GameObject player;
	bool first;	// only display instructions first time

	// Use this for initialization
	void Start () {
		first = true;
		text = "";
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent<gameLogic>().station == 1){
			if(first){
				text = "Find a way out.\nAstor Pl";
			}
			else{
				text = "Astor Pl";
			}
			//first = false;
		}
		else if(player.GetComponent<gameLogic>().station == 2){
			text = "59 St";
		}
		else if(player.GetComponent<gameLogic>().station == 3){
			text = "666 St";
		}
		else if(player.GetComponent<gameLogic>().station == 4){
			text = "City Hall";
		}
		else if(player.GetComponent<gameLogic>().station == 5){
			text = "Fulton St";
		}
		else if(player.GetComponent<gameLogic>().station == 6){
			text = "Broad St";
		}
		else if(player.GetComponent<gameLogic>().station == 7){
			text = "Court St";
		}
		else if(player.GetComponent<gameLogic>().station == 0){
			text = "We made it!";
		}
		else if(player.GetComponent<gameLogic>().station == 8){
			text = "Whoops.";
		}


		GetComponent<Text>().text = text;
	
	}
}
