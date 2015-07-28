using UnityEngine;
using System.Collections;

public class fadeToBlack : MonoBehaviour {
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
				GetComponent<Renderer>().enabled = true;
				timer = 5f;
				color = GetComponent<Renderer>().material.color;
				color.a = 0f;
				GetComponent<Renderer>().material.color = color;
				first = false;
			}
			timer -= Time.deltaTime;
			if(timer >= 0){
				color.a += 0.2f * Time.deltaTime;
				GetComponent<Renderer>().material.color = color;
			}
			else{
				first = true;
				start = false;
			}
		}
		
	}

	public void beginFade(){
		start = true;
	}
}
