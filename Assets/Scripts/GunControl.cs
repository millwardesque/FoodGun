using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {
	public Food currentFood;
	public GameObject[] targets;
	public Food cowFoodPrefab;
	public Food horseFoodPrefab;
	private GameObject currentTarget = null;

	// Use this for initialization
	void Start () {
		if (targets.Length > 0) {
			currentTarget = targets[0];
		}

		currentFood = cowFoodPrefab;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Food foodBullet = Instantiate<Food>(currentFood);
			foodBullet.transform.position = transform.position;
			Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
			foodBullet.GetComponent<Rigidbody2D>().AddForce(direction * 10f, ForceMode2D.Impulse);
		}

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

		if (Input.GetKeyDown (KeyCode.Q)) {
			SelectCowFood();
		}
		else if (Input.GetKeyDown (KeyCode.W)) {
			SelectHorseFood();
		}
	}

	public void ChangeTarget(int index) {
		if (targets.Length > index) {
			currentTarget = targets[index];
		}
	}

	public void SelectCowFood() {
		currentFood = cowFoodPrefab;
	}

	public void SelectHorseFood() {
		currentFood = horseFoodPrefab;
	}
}
