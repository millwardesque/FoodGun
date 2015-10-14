using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {
	public Food currentFood;
	public Target[] targets;
	public Food cowFoodPrefab;
	public Food horseFoodPrefab;

	private Target m_currentTarget = null;
	public Target CurrentTarget {
		get { return m_currentTarget; }
	}

	// Use this for initialization
	void Start () {
		if (targets.Length > 0) {
			m_currentTarget = targets[0];
		}

		currentFood = cowFoodPrefab;
	}
	
	// Update is called once per frame
	void Update () {
		// Fire food!
		if (Input.GetKeyDown (KeyCode.Space)) {
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

	public void ChangeTarget(int index) {
		if (targets.Length > index) {
			m_currentTarget = targets[index];
		}
	}

	public void SelectCowFood() {
		currentFood = cowFoodPrefab;
	}

	public void SelectHorseFood() {
		currentFood = horseFoodPrefab;
	}
}
