using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunControl : MonoBehaviour {
	public Food currentFood;
	public Food cowFoodPrefab;
	public Food horseFoodPrefab;

	public int numTargets = 5;
	private Target[] targets;

	private Target m_currentTarget = null;
	public Target CurrentTarget {
		get { return m_currentTarget; }
	}

	void Awake() {
		targets = new Target[5];
	}

	// Use this for initialization
	void Start () {
		if (targets.Length > 0 && targets[0] != null) {
			m_currentTarget = targets[0];
		}

		currentFood = cowFoodPrefab;
	}
	
	// Update is called once per frame
	void Update () {
		// Fire food!
		if (Input.GetKeyDown (KeyCode.Space) && CurrentTarget != null) {
			Food foodBullet = Instantiate<Food>(currentFood);
			foodBullet.transform.position = transform.position;
			Vector3 direction = (m_currentTarget.transform.position - transform.position).normalized;
			foodBullet.GetComponent<Rigidbody2D>().AddForce(direction * 10f, ForceMode2D.Impulse);
		}

		// Target selection
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ChangeTarget(0);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ChangeTarget(1);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ChangeTarget(2);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			ChangeTarget(3);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			ChangeTarget(4);
		}

		// Food controls
		if (Input.GetKeyDown (KeyCode.Q)) {
			SelectCowFood();
		}
		else if (Input.GetKeyDown (KeyCode.W)) {
			SelectHorseFood();
		}
	}

	public void ReplaceTarget(int index, Target target) {
		if (index >= 0 && index < targets.Length) {
			if (m_currentTarget == targets[index]) {
				m_currentTarget = target;
			}
			targets[index] = target;
		}
		else {
			Debug.LogError(string.Format ("Tried to replace target at invalid index position {0}. Targets array only supports {1} slots", index, targets.Length));
		}
	}

	public void ChangeTarget(int index) {
		if (HasTarget (index)) {
			m_currentTarget = targets[index];
		}
	}

	public int FindTargetIndex(Target target) {
		for (int i = 0; i < targets.Length; ++i) {
			if (targets[i] == target) {
				return i;
			}
		}
		return -1;
	}

	public void SelectCowFood() {
		currentFood = cowFoodPrefab;
	}

	public void SelectHorseFood() {
		currentFood = horseFoodPrefab;
	}

	public bool HasTarget(int index) {
		if (targets.Length > index && index >= 0 && targets[index] != null) {
			return true;
		}

		return false;
	}
}
