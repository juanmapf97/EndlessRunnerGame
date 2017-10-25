using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour {

	public Texture2D dialTex;
	public Texture2D needleTex;
	public Vector2 dialPos;
	public float topSpeed;
	public float stopAngle;
	public float topSpeedAngle;
	public float speed;
	private PlayerMovementController playerMov;

	// Use this for initialization
	void Start () {
		playerMov = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovementController>();
		speed = (float)playerMov.kph;
	}
	
	// Update is called once per frame
	void Update () {
		speed = (float)playerMov.kph;
	}

	void OnGUI() {
		speed = (float)playerMov.kph;
		GUI.DrawTexture(new Rect(dialPos.x, dialPos.y, dialTex.width/2, dialTex.height/2), dialTex);
		Vector2 centre = new Vector2(dialPos.x + (dialTex.width/2) / 2, dialPos.y + (dialTex.height/2) / 2);
		var savedMatrix = GUI.matrix;
		var speedFraction = speed / topSpeed;
		var needleAngle = Mathf.Lerp(stopAngle, topSpeedAngle, speedFraction);
		GUIUtility.RotateAroundPivot(needleAngle, centre);
		GUI.DrawTexture(new Rect(centre.x, centre.y - (needleTex.height/2) / 2, (needleTex.width/2), (needleTex.height/2)), needleTex);
		GUI.matrix = savedMatrix;
	}
}
