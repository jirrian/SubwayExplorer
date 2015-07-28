using UnityEngine;
using System.Collections;

public class fadeFromBlack : MonoBehaviour {
	public float timer;
	Color color;
	bool start = false;
	bool first;
	// Use this for initialization
	void Start () {
			first = true;	
	}
	
	// Update is called once per frame
	void Update () {
		if(start == true){
			if(first){
				timer = 10f;
				color = GetComponent<Renderer>().material.color;
				color.a = 1f;
				GetComponent<Renderer>().material.color = color;
				first = false;
			}
			timer -= Time.deltaTime;
			if(timer >= 0){
				color.a -= 0.1f * Time.deltaTime;
				GetComponent<Renderer>().material.color = color;
			}
			else{
				GetComponent<Renderer>().enabled = false;
				first = true;
				start = false;
			}
		}
		
	}

	public void beginFade(){
		start = true;
	}
}
