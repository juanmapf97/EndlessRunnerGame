using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	public Text speed;
	private int kph;
	private Vector3 previous;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (Vector3.forward * Input.GetAxis ("Mouse ScrollWheel"));
	}

	void FixedUpdate () {
		kph = (int)(((this.transform.position - previous).magnitude / Time.deltaTime)*3.6);
		previous = this.transform.position;
		speed.text = kph + " km/h";
	}
}
