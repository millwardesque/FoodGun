using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour {
	public Target[] targetTypes;


	public static TargetManager Instance = null;

	void Awake() {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy(gameObject);
		}
	}

	public Target CreateRandomTarget() {
		int typeIndex = Random.Range(0, targetTypes.Length);
		Target newTarget = Instantiate<Target>(targetTypes[typeIndex]);
		newTarget.transform.SetParent(transform, true);


		newTarget.state = TargetState.Hungry;
		newTarget.CurrentHunger = Random.Range(1f, newTarget.maxHunger);
		return newTarget;
	}
}
