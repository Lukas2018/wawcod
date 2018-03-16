using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Rot : MonoBehaviour
{
	public Transform target1;
	public Transform target2;
	Vector3 pos1, pos2;

	void Start()
	{
		pos1 = target1.localPosition;
		pos2 = target2.localPosition;
		StartCoroutine(CoShowStart());
	}

	IEnumerator CoShowStart()
	{
		yield return new WaitForSeconds(2f);
		ShowTweenMove(target1, pos1 + Vector3.left * 500f, pos1, Ease.OutBack);
		yield return new WaitForSeconds(0.1f);
		ShowTweenMove(target2, pos2 + Vector3.right * 500f, pos2, Ease.OutBack);
		StartCoroutine(CoShowTweenMotion(target1, false, 6));
		yield return new WaitForSeconds(0.1f);
		StartCoroutine(CoShowTweenMotion(target2, false, 6));
		yield return new WaitForSeconds(14f);
		ShowTweenMove(target1, pos1, pos1 + Vector3.left * 500f, Ease.InBack);
		yield return new WaitForSeconds(0.1f);
		ShowTweenMove(target2, pos2, pos2 + Vector3.right * 500f, Ease.InBack);
		StartCoroutine(CoShowStart());
	}

	IEnumerator CoShowTweenMotion(Transform target, bool isOn, int count)
	{
		yield return new WaitForSeconds(2f);
		ShowTweenRotate(target, isOn);
		isOn = !isOn;
		count--;
		if (count < 1) yield break;
		StartCoroutine(CoShowTweenMotion(target, isOn, count));
	}

	void ShowTweenRotate(Transform target, bool val)
	{
		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(target.DORotate(new Vector3(0f, 90f, 0f), 0.1f).SetEase(Ease.Linear)
			.OnComplete(() => { target.GetComponentInChildren<Text>().enabled = val; }));
		mySequence.Append(target.DORotate(new Vector3(0f, 0f, 0f), 0.1f).SetEase(Ease.Linear));
		mySequence.Play();
	}

	void ShowTweenMove(Transform target, Vector3 pos1, Vector3 pos2, Ease easeType)
	{
		target.localPosition = pos1;
		target.DOLocalMove(pos2, 0.3f).SetEase(easeType);
	}
}
