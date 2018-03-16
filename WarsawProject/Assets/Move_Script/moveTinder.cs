using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTinder : MonoBehaviour {

	Vector3 actual_pos, actual_rot;
	float offsetX;
	float offsetY;
	public float div_num;
	public GameObject tak, nie;
	private Zab_db zb;
	// Use this for initialization
	void Start () {
		zb = GameObject.FindObjectOfType<Zab_db> ();
		actual_pos = transform.position;
		actual_rot = transform.localEulerAngles;
	}

	public void BeginDrag(){
		offsetX = transform.position.x - Input.mousePosition.x;
		offsetY = transform.position.y - Input.mousePosition.y;
	}

	public void OnDrag(){
		transform.position = new Vector3 (offsetX + Input.mousePosition.x, transform.position.y);
		transform.localEulerAngles = new Vector3 (0, 0, -((offsetX + Input.mousePosition.x - actual_pos.x)/div_num));
		if (offsetX + Input.mousePosition.x - actual_pos.x > 0) {
			tak.SetActive (true);
			nie.SetActive (false);
		}else if(offsetX + Input.mousePosition.x - actual_pos.x == 0) {
			tak.SetActive (false);
			nie.SetActive (false);
		} else {
			tak.SetActive (false);
			nie.SetActive (true);
		}
		//GetComponent<RectTransform> ().localRotation.z = offsetX + Input.mousePosition.x - actual_pos.x;
		//transform.rotation = new Vector3 (offsetX + Input.mousePosition.x - actual_pos.x, 0 , 0);
		//transform.rotation = new Vector3 ();
	}

	public void OnMouseUp(){
		//Instantiate (zb.zabytki [0]);
		transform.position = actual_pos;
		transform.localEulerAngles = actual_rot;
		tak.SetActive (false);
		nie.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
