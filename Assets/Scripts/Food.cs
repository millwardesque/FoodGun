using UnityEngine;
using System.Collections;

public enum FoodType {
	Cow,
	Horse
};

public class Food : MonoBehaviour {
	public FoodType type = FoodType.Cow;
	public float lifespan = 5f;


	void Update() {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0f) {
			Destroy(gameObject);
		}
	}
}
