using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveInit : MonoBehaviour {

    public Camera waveCam;
    public Material waveMat;
    public UnityEngine.UI.RawImage waveRImage;
    

	// Use this for initialization
	void Start () {
        RenderTexture waveTex = new RenderTexture(Screen.width, Screen.height, 0);
        waveCam.targetTexture = waveTex;
        waveMat.mainTexture = waveTex;
        // Has to be done with an raw Image!
        waveRImage.texture = waveTex;
        waveRImage.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);

    }
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
