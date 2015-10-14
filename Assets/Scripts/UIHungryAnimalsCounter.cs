using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class UIHungryAnimalsCounter : MonoBehaviour {
	int m_hungryAnimals;
	public int HungryAnimals {
		get { return m_hungryAnimals; }
		set {
			m_hungryAnimals = value;
			RefreshUI();
		}
	}

	void RefreshUI() {
		GetComponent<Text>().text = string.Format("Hungry Animals: {0}", HungryAnimals);
	}
}
