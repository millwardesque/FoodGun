using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {
	public GameObject bulletPrefab;
	public GameObject[] targets;
	private GameObject currentTarget = null;

	// Use this for initialization
	void Start () {
		if (targets.Length > 0) {
			currentTarget = targets[0];
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject bullet = Instantiate<GameObject>(bulletPrefab);
			bullet.transform.position = transform.position;
			Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
			bullet.GetComponent<Rigidbody2D>().AddForce(direction * 10f, ForceMode2D.Impulse);
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
	}

	public void ChangeTarget(int index) {
		if (targets.Length > index) {
			currentTarget = targets[index];
		}
	}
}
