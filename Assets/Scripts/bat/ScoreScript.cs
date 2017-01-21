using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	public float scorePerSecond;
	public Text scoreTextWidet;
	public float timeBetweenFlashes;
	public int timesToFlash;

	private float currentScore;

	private int timesFlashed;
	private float timeSinceLastFlash;


	// Use this for initialization
	void Start () {
		currentScore = 0;
		timesFlashed = timesFlashed* 2;
		timeSinceLastFlash = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.addScore(scorePerSecond * Time.deltaTime, false);
		if (timesFlashed < timesToFlash * 2) {
			if (timeSinceLastFlash > timeBetweenFlashes) {
				timeSinceLastFlash = 0;
				timesFlashed++;
				scoreTextWidet.enabled = !scoreTextWidet.enabled;
			}
			timeSinceLastFlash += Time.deltaTime;
		} else {
			scoreTextWidet.enabled = true;
		}
	}

	public void addScore(float amount, bool flash){
		currentScore += amount;
		scoreTextWidet.text = ((int)currentScore).ToString();
		if (flash && timesFlashed==timesToFlash*2) {
			timesFlashed = 0;
		}
	}
}
