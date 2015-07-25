using UnityEngine;
using System.Collections;

public class gameLogic : MonoBehaviour {
	int station = 1; // number representing current station
		// 1 = start/default
		// 2, 4, 5 = connecting stations
		// 3, 6 = dead end
		// 7 = win/end of game
		/* BASIC MAP
				  3
				  |
				  2
				 / \
				1   4
				| / |
				5   7
				|
				6
		*/
	int train = 000;	// number representing current train at current station
		// 3 digits:
		// 1st digit = # of station
		// 2nd digit = platform (1 = northbound, 0 = southbound)
		// 3rd digit = # train for platform for station

	float timer;	// counter for time
	float stopTime; // time train remains stopped

	GameObject[] nTrains;
	GameObject[] sTrains;
	GameObject[] platform;
	bool stopped;	// train stopped and waiting for passengers
	bool setRest;	// set all cars to resting position

	bool posSetRest = false;
	bool negSetRest = false;

	// initialization at entering new station
	void Start () {
		setRest = false;
		Reset();
		stopped = false;
		nTrains = GameObject.FindGameObjectsWithTag("nTrains"); // array of northbound trains
		sTrains = GameObject.FindGameObjectsWithTag("sTrains"); // array of southbound trains

	}
	
	// Update is called once per frame
	void Update () {
		if(station == 1){
			enterExit(true);
			enterExit(false);
		}
	
	}

	// HELPER FUNCTIONS!!

	// set timers
	void Reset(){
		timer = Random.Range(30.0f, 50.0f);
	//	timer2 = timer1 + Random.Range(20.0f, 25.0f);
		stopTime = 5.0f;
	}

	// manages train enter->stop->exit for either platform
	void enterExit(bool isPos){
		timer -= Time.deltaTime;	// countdown until train arrives
		if(isPos){	// northbound trains
			platform = nTrains;
		}
		else{	// southbound trains
			platform = sTrains;
		}
			if(timer <= 0){
				// start trains
				foreach (GameObject train in platform){	// indicate trains are entering and slowing down
					train.GetComponent<trainController>().stopTrain(isPos);
					if(train.GetComponent<trainController>().speed <= 0){
						stopped = true;
					}
				}
				if(stopped == true){
			//		Debug.Log("waiting to start " + stopTime);
					stopTime -= Time.deltaTime;	// wait while stopped
					if(stopTime <= 0){
			//			Debug.Log("starting");
						foreach (GameObject train in platform){	// indicate trains are leaving and speeding up
							train.GetComponent<trainController>().startTrain(isPos);
						//	if(train.GetComponent<trainController>().speed >= 20f){
								// if one train is at rest position, set all trains to stop
						/*		if(train.GetComponent<trainController>().negRest == true || 
									train.GetComponent<trainController>().posRest == true){
									setRest = true;
									break;
								}
						*/
					/*			if(train.GetComponent<trainController>().posRest == true){
									posSetRest = true;
									break;
								}
								else if(train.GetComponent<trainController>().negRest == true){
									negSetRest = true;
									break;
								}
							}
					*/
						}
					}
				}
			}
	/*	if(setRest || posSetRest || negSetRest){	// set all other trains to stop
			foreach (GameObject train in platform){
				if(isPos && posSetRest){
					train.GetComponent<trainController>().posRest = true;
					Debug.Log(train.GetComponent<trainController>().posRest);
					stopped = false;
				}
				else if (!isPos && negSetRest){
					train.GetComponent<trainController>().negRest = true;
					stopped = false;
				}
			}
		}
	*/
	}

	
}
