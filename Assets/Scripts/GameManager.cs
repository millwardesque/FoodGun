using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager Instance = null;

	void Awake() {
		if (null == Instance) {
			Instance = this;
		}
		else {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Called whenever a target reaches the Full state.
	/// </summary>
	public void OnTargetFull() {
		Target[] targets = GameObject.FindObjectsOfType<Target>();

		bool areAllFull = true;
		for (int i = 0; i < targets.Length; ++i) {
			if (targets[i].state != TargetState.Full) {
				areAllFull = false;
				break;
			}
		}

		if (areAllFull) {
			PlayerWins ();
		}
	}

	/// <summary>
	/// Called when the player runs out of time.
	/// </summary>
	public void OnOutOfTime() {
		PlayerLoses();
	}

	void PlayerWins() {
		Debug.Log("YOU WIN!");
		Time.timeScale = 0f;
	}

	void PlayerLoses() {
		Debug.Log ("YOU LOSE!");
		Time.timeScale = 0f;
	}
}
