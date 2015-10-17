using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public float duration = 1f;
    float timeRemaining;
    bool isRunning = false;

	// Use this for initialization
	void Start () {
        timeRemaining = duration;
        isRunning = true;	
	}
	
	// Update is called once per frame
	void Update () {
	    if (isRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0f)
            {
                isRunning = false;
                OnTimeUp();
            }
        }
	}

    protected virtual void OnTimeUp()
    {
        // @ TODO Override this in subclasses.
        Destroy(gameObject);
    }
}
