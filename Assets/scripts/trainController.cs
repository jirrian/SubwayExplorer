using UnityEngine;
using System.Collections;

public class trainController : MonoBehaviour {
	public float speed = 20;
	public bool positive;	// if moving in positive direction (northbound)

	bool posStop;	// if stopping (entering)
	bool negStop;

	bool negLeaving;	// if leaving station
	bool posLeaving;

	public bool posRest;	// train is in default position off screen
	public bool negRest;

	float defaultX;	// store position car is in originally
	float defaultY;
	float defaultZ;

	// Use this for initialization
	void Start () {
		defaultX = transform.position.x;
		defaultY = transform.position.y;
		defaultZ = transform.position.z;
		resetCar();
	}
	
	// Update is called once per frame
	void Update () {

		if(positive && !posStop && !posRest){	// northbound trains moving
			if(speed <= 20f){
		//		Debug.Log("speedingup " + speed);
				speed += Time.deltaTime;
			}
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
			if(transform.position.x >= 70f && speed < 20f && !posRest){
				transform.position = new Vector3(-70f, defaultY, defaultZ);
			}
			if(speed >= 20f && transform.position.x >= 200f){
				posRest = true;
			}
		}
		else if(!positive && !negStop && !negRest){	// southbound trains moving
			if(speed <= 20f){
				speed += Time.deltaTime;
			}
			transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * speed;
			if(transform.position.x <= -70f && speed < 20f){
				transform.position = new Vector3(70f, defaultY, defaultZ);
			}
			if(speed >= 20f && transform.position.x <= -200f){
				negRest = true;
			}
		}
		else if(positive && posStop){	// northbound trains slowing down
			posRest = false;
			if(speed > 0){
				speed -= Time.deltaTime;
			}
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
			if(transform.position.x >= 70f){
				transform.position = new Vector3(-70f, defaultY, defaultZ);
			}
	
		}
		else if(!positive && negStop){	// southbound trains slowing down
			negRest = false;
			if(speed > 0){
				speed -= Time.deltaTime;
			}
			transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * speed;
			if(transform.position.x <= -70f){
				transform.position = new Vector3(70f, defaultY, defaultZ);
			}
		}
		else if (posRest){
			transform.position = new Vector3(defaultX, defaultY, defaultZ);
		}
		else if (negRest){
			transform.position = new Vector3(defaultX, defaultY, defaultZ);
		}
	}
	// TODO: implement stop and start function (gradual stop - reduce speed)

	// HELPER FUNCTIONS

	// sets markers for stopping either train for ENTER
	public void stopTrain(bool isPositive){
		if(isPositive){
			posStop = true;

		}
		else{
			negStop = true;
		}
	}
	// sets markers for starting either train for EXIT 
	public void startTrain(bool isPositive){
		if(isPositive){	// northbound trains
			posStop = false;
		//	Debug.Log("NORTH starting");
		}
		else{ // sountbound trains
			negStop = false;
		//	Debug.Log("SOUTH starting");	
		}
	}

	// reset settings and location of car
	public void resetCar(){
		transform.position = new Vector3(defaultX, defaultY, defaultZ);
		posStop = true;
		negStop = true;
		posRest = false;
		negRest = false;
	}
}
