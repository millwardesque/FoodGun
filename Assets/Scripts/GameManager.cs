using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager Instance = null;
	public GameObject youWinContainer;
	public GameObject youLoseContainer;
	public UITimer timer;

	void Awake() {
		if (null == Instance) {
			Instance = this;
		}
		else {
			Destroy(gameObject);
		}
	}

	void Start() {
		StartNewGame();
	}

	/// <summary>
	/// Called whenever a target reaches the Full state.
	/// </summary>
	public void OnTargetFull() {
		Target[] targets = GetTargets();

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

	public void OnStartNewGame() {
		StartNewGame();
	}

	void StartNewGame() {
		youWinContainer.SetActive(false);
		youLoseContainer.SetActive(false);

		RandomizeTargetsHunger();
		Time.timeScale = 1f;
		timer.state = TimerState.Started;

		RemoveBullets();
	}

	Target[] GetTargets() {
		 return GameObject.FindObjectsOfType<Target>();
	}

	void RandomizeTargetsHunger() {
		Target[] targets = GetTargets();
		for (int i = 0; i < targets.Length; ++i) {
			targets[i].state = TargetState.Hungry;
			targets[i].CurrentHunger = Random.Range(1f, targets[i].maxHunger);
		}
	}

	void RemoveBullets() {
		GameObject[] food = GameObject.FindGameObjectsWithTag("Food");
		for (int i = 0; i < food.Length; ++i) {
			GameObject.Destroy(food[i]);
		}
	}

	void PlayerWins() {
		youWinContainer.SetActive(true);
		Time.timeScale = 0f;
		timer.state = TimerState.Stopped;
	}

	void PlayerLoses() {
		youLoseContainer.SetActive(true);
		Time.timeScale = 0f;
		timer.state = TimerState.Stopped;
	}
}
