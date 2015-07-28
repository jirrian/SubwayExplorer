using UnityEngine;
using System.Collections;

public class gameLogic : MonoBehaviour {
	public int station = 1; // number representing current station
		// 1 = start/default
		// 2, 4, 5 = connecting stations
		// 3, 6 = dead end
		// 7 = last station
		// 0 = win game state
		// 8 = get hit by train
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

	public int change; // change stations or not
		// 0 = no change
		// 10 = change north
		// 11 = change south;
	int count; // # of times train entered

	float timer;	// counter for time
	float stopTimeN, stopTimeS; // time train remains stopped
	float timerN, timerS;

	GameObject[] nTrains;
	GameObject[] sTrains;
	GameObject[] platform;
	GameObject[] sevenObjs;

	bool stoppedN, stoppedS;	// train stopped and waiting for passengers
	bool setRest;	// set all cars to resting position
	bool resetN, resetS;

	public GameObject fade;

	//public AudioSource[] aSources;
	/*public AudioSource arrive;
	public AudioSource depart;
	public AudioSource end;
	public AudioSource ambient;
*/
	// initialization at entering new station
	void Start () {
		ResetS();
		ResetN();
		nTrains = GameObject.FindGameObjectsWithTag("nTrains"); // array of northbound trains
		sTrains = GameObject.FindGameObjectsWithTag("sTrains"); // array of southbound trains
		change = 0;
		count = 0;

		sevenObjs = GameObject.FindGameObjectsWithTag("seven");

		fade.GetComponent<fadeFromBlack>().beginFade();

	//	aSources = GetComponents<AudioSource>();
	/*	ambient = aSources[0];
		end = aSources[1];
		arrive = aSources[2];
		depart = aSources[3];
*/
	}
	
	// Update is called once per frame
	void Update () {
		// trains and connections for each station
		if(station == 1){
			//fade.GetComponent<fadeFromBlack>().beginFade();
			
			enterExit(true);
			enterExit(false);
			if(change != 0){

				setStation();
			}
		}
		else if (station == 2){
		//	fade.GetComponent<fadeFromBlack>().beginFade();
			enterExit(true);
			enterExit(false);
			if(change != 0){
				setStation();
			}
		}
		else if (station == 3){
		//	fade.GetComponent<fadeFromBlack>().beginFade();
			enterExit(false);
			if(change != 0){
				setStation();
			}
		}
		else if (station == 4){
		//	fade.GetComponent<fadeFromBlack>().beginFade();
			enterExit(true);
			enterExit(false);
			if(change != 0){
				setStation();
			}
		}
		else if (station == 5){
		//	fade.GetComponent<fadeFromBlack>().beginFade();
			enterExit(true);
			enterExit(false);
			if(change != 0){
				setStation();
			}
		}
		else if (station == 6){
		//	fade.GetComponent<fadeFromBlack>().beginFade();
			enterExit(true);
			if(change != 0){
				setStation();
			}
		}
		else if (station == 7){
		//	fade.GetComponent<fadeFromBlack>().beginFade();
			foreach(GameObject obj in sevenObjs){
				obj.GetComponent<showStairs>().isSeven = true;
			}
			//end.Play();
		}
		else if(station == 0){	// end of game
		//	ambient.Stop();
		}
		else if(station == 8){	// if you get hit by a train
			//nothing happens
		}
	
	}

	// HELPER FUNCTIONS!!

	// set timers
	void ResetN(){
		timerN = Random.Range(30.0f, 50.0f);
		stopTimeN = 5.0f;
		stoppedN = false;
		resetN = false;
	}

	void ResetS(){
		count++;
		timerS = Random.Range(30.0f, 50.0f);
		stopTimeS = 5.0f;
		stoppedS = false;
		resetS = false;
	}


	// manages train enter->stop->exit for either platform
	void enterExit(bool isPos){
	//	Debug.Log(timer);
	
		if(isPos){	// northbound trains
			platform = nTrains;
			timerN -= Time.deltaTime;	// countdown until train arrives
			if(timerN <= 0){
				// start trains
				//arrive.Play();
				foreach (GameObject train in platform){	// indicate trains are entering and slowing down
					train.GetComponent<trainController>().stopTrain(isPos);
					if(train.GetComponent<trainController>().speed <= 0){
						//arrive.Stop();
						stoppedN = true;
						
					}
					else if(train.GetComponent<trainController>().speed > 0f && checkRest(platform, isPos)){
						resetN = true;
					//	aSources[3].Stop();
						if(resetN == true){
							ResetN();
						}
					}
			
				}

				if(stoppedN == true){
					stopTimeN -= Time.deltaTime;	// wait while stopped
					if(stopTimeN <= 0){
					//	aSources[3].Play();
						foreach (GameObject train in platform){	// indicate trains are leaving and speeding up
							train.GetComponent<trainController>().startTrain(isPos);
						}
					}
				}
			}
		}
		else{	// southbound trains
			platform = sTrains;
			timerS -= Time.deltaTime;	// countdown until train arrives
			if(timerS <= 0){
				// start trains
			//	aSources[2].Play();
				foreach (GameObject train in platform){	// indicate trains are entering and slowing down
					train.GetComponent<trainController>().stopTrain(isPos);
					if(train.GetComponent<trainController>().speed <= 0){
					//	aSources[2].Stop();
						stoppedS = true;
					}
					else if(train.GetComponent<trainController>().speed > 0f && checkRest(platform, isPos)){
						resetS = true;
					//	aSources[3].Stop();
						if(resetS == true){
							ResetS();
						}
					}
			
				}
				if(stoppedS == true){
					stopTimeS -= Time.deltaTime;	// wait while stopped
					if(stopTimeS <= 0){
					//	aSources[3].Play();
						foreach (GameObject train in platform){	// indicate trains are leaving and speeding up
							train.GetComponent<trainController>().startTrain(isPos);
						}
					}
				}
			}				
		}
	}

	// checks if all train cars are resting
	bool checkRest(GameObject[] trains, bool isPos){
		bool isRest = true;
		foreach (GameObject train in trains){
			if (isPos){
				if(train.GetComponent<trainController>().posRest != true){
					isRest = false;
				}
			}else{
				if(train.GetComponent<trainController>().negRest != true){
					isRest = false;
				}
			}
		}
		Debug.Log(isRest);
		return isRest;
	}

	// change station number
	void setStation(){
		if(station == 1){
			if(change == 10){
				station = 2;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
			else if(change == 11){
				station = 5;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
		}
		else if(station == 2){
			if(change == 10){
				station = 3;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
			else if(change == 11){
				if(count % 2 == 0){
					station = 4;
					fade.GetComponent<fadeFromBlack>().beginFade();
				}
				else{
					station = 1;
					fade.GetComponent<fadeFromBlack>().beginFade();
				}
			}
		}
		else if(station == 3){
			if(change == 10){
				station = 0;	// null station
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
			else if(change == 11){
				station = 2;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
		}
		else if(station == 4){
			if(change == 10){
				station = 2;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
			else if(change == 11){
				station = 7;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
		}
		else if(station == 5){
			if(change == 10){
				station = 4;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
			else if(change == 11){
				station = 6;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
		}
		else if(station == 6){
			if(change == 10){
				station = 5;
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
			else if(change == 11){
				station = 0;	// null station
				fade.GetComponent<fadeFromBlack>().beginFade();
			}
		}

		// reset position of cars and settings
		ResetS();
		ResetN();
		count = 0;
		change = 0;
		foreach (GameObject train in nTrains){
			train.GetComponent<trainController>().resetCar();
		}
		foreach (GameObject train in sTrains){
			train.GetComponent<trainController>().resetCar();
		}
		
	}

	
}
