using UnityEngine;
using System.Collections;

public enum TargetState {
	Hungry,
	Full
};

public class Target : MonoBehaviour {
	public float maxHunger = 100f;			// Max amount of hungry the target can be
	public float hungerIncreaseRate = 1.0f; // Rate at which hunger increases (per second)
	public float foodHungerReduction = 5f;	// Amount of hunger that food reduces
	public float fullDuration = 5f;			// Time for which the target stays full.
	public float currentFullDuration = 0f;	// Time remaining during which the target stays full.
	public FoodType foodType = FoodType.Cow;	// Type of food this animal eats

	TargetState m_state = TargetState.Hungry;
	public TargetState state {
		get { return m_state; }
		set {
			TargetState oldState = m_state;
			m_state = value;
			if (oldState == TargetState.Hungry && m_state == TargetState.Full) {
				currentFullDuration = fullDuration;
				GameManager.Instance.OnTargetFull();
			}
			else if (oldState == TargetState.Full && m_state == TargetState.Hungry) {
				m_currentHunger = 0f;
			}
		}
	}

	float m_currentHunger = 0f;
	public float CurrentHunger {
		get { return m_currentHunger; }
		set { m_currentHunger = Mathf.Clamp(value, 0f, maxHunger); }
	}

	void Update() {
		if (state == TargetState.Hungry) {
			m_currentHunger += Time.deltaTime * hungerIncreaseRate;
			m_currentHunger = Mathf.Clamp(m_currentHunger, 0f, maxHunger);

			if (Mathf.Abs(m_currentHunger) < float.Epsilon) {
				state = TargetState.Full;
			}
		}
		else if (state == TargetState.Full) {
			currentFullDuration -= Time.deltaTime;
			if (currentFullDuration < 0f) {
				state = TargetState.Hungry;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		Food colliderFood = col.collider.GetComponent<Food>();
		if (colliderFood != null) {
			if (state == TargetState.Hungry) {
				if (colliderFood.type == foodType) {
					m_currentHunger -= foodHungerReduction;
				}
				else {
					m_currentHunger += foodHungerReduction;
				}
			}

			Destroy (col.collider.gameObject);
		}
	}
}
