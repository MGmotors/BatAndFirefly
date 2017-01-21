using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	public float scorePerSecond;
	public Text scoreTextWidet;

	private float currentScore;

	// Use this for initialization
	void Start () {
		currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.addScore(scorePerSecond * Time.deltaTime);
	}

	public void addScore(float amount){
		currentScore += amount;
		scoreTextWidet.text = "SCORE: " + currentScore.ToString();
	}
}
