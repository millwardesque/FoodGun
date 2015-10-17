using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour {
	public Target[] targetTypes;
    public TargetSpawnTimer targetSpawnTimerPrefab;
    public float spawnDelay = 5f;

    public static TargetManager Instance = null;

	void Awake() {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy(gameObject);
		}
	}

    public TargetSpawnTimer CreateSpawnTimer(int spawnPosition)
    {
        TargetSpawnTimer newTimer = GameObject.Instantiate<TargetSpawnTimer>(targetSpawnTimerPrefab);
        newTimer.spawnPosition = spawnPosition;
        newTimer.duration = spawnDelay;
        newTimer.transform.SetParent(transform);
        return newTimer;
    }

	public Target CreateRandomTarget(Vector3 localPosition) {
		int typeIndex = Random.Range(0, targetTypes.Length);
		Target newTarget = Instantiate<Target>(targetTypes[typeIndex]);
		newTarget.transform.SetParent(transform, true);

		newTarget.transform.localPosition = localPosition;
		newTarget.state = TargetState.Hungry;
		newTarget.CurrentHunger = Random.Range(1f, newTarget.maxHunger);
		return newTarget;
	}

	public Target[] GetTargets() {
		return this.gameObject.GetComponentsInChildren<Target>();
	}
}
