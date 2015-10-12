using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum TimerState {
	Started,
	Stopped
};

[RequireComponent (typeof(Text))]
public class UITimer : MonoBehaviour {
	Text timerLabel;
	public float gameLength = 60f;
	float timeRemaining;

	private TimerState m_state;
	public TimerState state {
		get { return m_state; }
		set { m_state = value; }
	}

	void Start() {
		timerLabel = GetComponent<Text>();
		timeRemaining = gameLength;
		state = TimerState.Started;
	}

	// Update is called once per frame
	void Update () {
		if (state == TimerState.Started) {
			timeRemaining -= Time.deltaTime;
			timerLabel.text = string.Format("Time Remaining: {0}", Mathf.RoundToInt(timeRemaining));

			if (timeRemaining < 0f) {
				GameManager.Instance.OnOutOfTime();
				state = TimerState.Stopped;
			}
		}
	}
}
