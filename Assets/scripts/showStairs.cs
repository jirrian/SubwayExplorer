using UnityEngine;
using System.Collections;

public class showStairs : MonoBehaviour {
	public bool isSeven;

	// Use this for initialization
	void Start () {
		isSeven = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isSeven == true){
			Debug.Log("Seven");
			foreach (Transform child in transform){
  				child.gameObject.SetActive(true);
			}
		}
	}
}
