using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Target))]
[RequireComponent (typeof(SpriteRenderer))]
public class TargetHungerVisualizer : MonoBehaviour {
	SpriteRenderer sprite;
	Target target;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();
		target = GetComponent<Target>();
	}

	void LateUpdate() {

		if (target.state == TargetState.Hungry) {
			float colorValue = (target.maxHunger - target.CurrentHunger) / target.maxHunger;
			Color newColor = new Color(1f - colorValue, colorValue, 0f);
			sprite.color = newColor;
		}
		else if (target.state == TargetState.Full) {
			sprite.color = Color.blue;
		}
	}
}
