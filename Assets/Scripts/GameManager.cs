using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager Instance = null;
	public GameObject youWinContainer;
	public GameObject youLoseContainer;
	public GameObject foodOptionContainer;
	public GunControl player;
	public UITimer timer;
	public UIHungryAnimalsCounter hungryAnimalsCounter;
	public int startingHungryAnimalCount;

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
	public void OnTargetFull(Target target) {
		if (hungryAnimalsCounter.HungryAnimals > 0) {
			hungryAnimalsCounter.HungryAnimals--;
			Target newTarget = TargetManager.Instance.CreateRandomTarget();
			newTarget.transform.position = target.transform.position;
			
			for (int i = 0; i < player.targets.Length; ++i) {
				if (target == player.targets[i]) {
					player.targets[i] = newTarget;

					if (target == player.CurrentTarget) {
						player.ChangeTarget(i);
					}
				}
			}

			Destroy (target.gameObject);
		}
		else {
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
		foodOptionContainer.SetActive(true);
		hungryAnimalsCounter.HungryAnimals = startingHungryAnimalCount;

		RandomizeTargets();
		Time.timeScale = 1f;
		timer.state = TimerState.Started;

		RemoveBullets();
	}

	Target[] GetTargets() {
		 return GameObject.FindObjectsOfType<Target>();
	}

	void RandomizeTargets() {
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
		foodOptionContainer.SetActive(false);
		Time.timeScale = 0f;
		timer.state = TimerState.Stopped;
	}

	void PlayerLoses() {
		youLoseContainer.SetActive(true);
		foodOptionContainer.SetActive(false);
		Time.timeScale = 0f;
		timer.state = TimerState.Stopped;
	}
}
