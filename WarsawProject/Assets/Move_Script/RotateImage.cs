using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateImage : MonoBehaviour {

	private Transform target;
	private int i = 0;
	public bool ss = true;

	// Use this for initialization
	void Start () {
		target = gameObject.transform;
		StartCoroutine (WaitforDC ());
	}

	IEnumerator WaitforDC(){
		while (ss) {
			target.DORotate(new Vector3(0, 0, -30f), 0.01f).SetRelative().SetLoops(1, LoopType.Incremental);
			yield return new WaitForSeconds (0.1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
