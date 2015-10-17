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
	private float fieldWidth = 18f;

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

	public Vector2 CalculateLocalPosition(int index) {
		float x = (-fieldWidth / 2f) + (index * fieldWidth / player.numTargets);
		float y = 0f;

		return new Vector2(x, y);
	}

	/// <summary>
	/// Called whenever a target reaches the Full state.
	/// </summary>
	public void OnTargetFull(Target target) {
		hungryAnimalsCounter.HungryAnimals--;
        Destroy(target.gameObject);
        if (hungryAnimalsCounter.HungryAnimals > 0) {
			int targetIndex = player.FindTargetIndex(target);

			if (hungryAnimalsCounter.HungryAnimals >= player.numTargets) {
				if (targetIndex != -1) {
                    TargetManager.Instance.CreateSpawnTimer(targetIndex);
					// Target newTarget = TargetManager.Instance.CreateRandomTarget(CalculateLocalPosition(targetIndex));
					// player.ReplaceTarget(targetIndex, newTarget);
				}
			}
			/*else { // If there aren't any more animals to queue up, move the player to a different target.
				int i = (targetIndex + 1) % player.numTargets;
				while (i != targetIndex) {
					if (player.HasTarget(i)) {
						player.ChangeTarget(i);
						break;
					}
					i = (i + 1) % player.numTargets;
				}
			}*/
			
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

	void RandomizeTargets() {
		for (int i = 0; i < player.numTargets; ++i) {
			Target target = TargetManager.Instance.CreateRandomTarget(CalculateLocalPosition(i));
			player.ReplaceTarget(i, target);
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
