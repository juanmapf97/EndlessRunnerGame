using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpController : MonoBehaviour {

	public GameObject Obstacle;

	// Use this for initialization
	void Start () {
		RepopulateObstacles ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log ("Trigger Enter");
		if (col.gameObject.tag == "Player") {
			RepopulateObstacles ();
			col.gameObject.transform.position = new Vector3 (272f, 3f, 199f);
		}
	}

	void RepopulateObstacles ()
	{
		DestroyClones ();
		for (int i = 0; i < 50; i++) {
			var clone = Instantiate (Obstacle, new Vector3 (Random.Range (250, 290), 2.5f, Random.Range (-390f, 900f)), new Quaternion(0, 0, 0, 0));
			clone.tag = "Clone";
		}
	}

	void DestroyClones() {
		var clones = GameObject.FindGameObjectsWithTag ("Clone");
		foreach (var clone in clones){
			Destroy(clone);
		}
	}
}
