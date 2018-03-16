using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Karta : MonoBehaviour {

	public GameObject[] im;
	public bool ob1;
	public float czas_przejscie;
	public float value_alpha;
	public float value_div;
	public string nazwa_Zabytku;

	// Use this for initialization
	void Start () {
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
		foreach (Image gb in GetComponentsInParent<Image>()) {
			if (gb.gameObject.name == "Glowny") {
				Debug.Log ("found1" + gb.gameObject.name);
				foreach (Text gba in gb.gameObject.GetComponentsInChildren<Text>()) {
					Debug.Log ("found2" + gba.gameObject.name);
					if (gba.gameObject.name == "name_zb") {
						Debug.Log ("found3" + gba.gameObject.name);
						gba.GetComponent<Text> ().text = nazwa_Zabytku;
					}
				}
			}
		}
		//mySequence.SetLoops(4, LoopType.Restart);
	}

	IEnumerator CoShowStart()
	{
		yield return new WaitForSeconds(0.1f);
		StartCoroutine(CoShowTweenMotion(im[0].transform, true, 2));
	}

	public void OnClickThis(){
		StartCoroutine(CoShowStart());
	}

	IEnumerator CoShowTweenMotion(Transform target, bool isOn, int count)
	{
		yield return new WaitForSeconds(0.5f);
		ShowTweenRotate(target, isOn);
		isOn = !isOn;
		count--;
		if (count < 1) yield break;
		yield return new WaitForSeconds(czas_przejscie);
		StartCoroutine(CoShowTweenMotion(target, isOn, count));
	}

	void ShowTweenRotate(Transform target, bool val)
	{
		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(target.DORotate(new Vector3(0f, 90f, 0f), 0.1f).SetEase(Ease.Linear)
			.OnComplete(() => { target.GetComponentInChildren<Text>().enabled = val;
				foreach(Image img in target.GetComponentsInChildren<Image>()){
					if(img.gameObject.name == "Zabytek")
						img.enabled = !val;
				}
				target.GetComponentInChildren<Button>().enabled = !val;
				}));
		mySequence.Append(target.DORotate(new Vector3(0f, 0f, 0f), 0.1f).SetEase(Ease.Linear));
		mySequence.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
