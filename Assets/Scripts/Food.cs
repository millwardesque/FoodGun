using UnityEngine;
using System.Collections;

public enum FoodType {
	Cow,
	Horse
};

public class Food : MonoBehaviour {
	public FoodType type = FoodType.Cow;
}
