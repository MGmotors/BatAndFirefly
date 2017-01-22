using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScrollScript : MonoBehaviour {
    public GameObject autoP, busP, baumP, postP, bushalteP, garbageP, highlampP, hanglampP, opaP;
    public GameObject fireflySwarm;
    public GameObject mapBlock;
    public Material waveMaterial;
    public Camera mainCam;
    public GameObject mouse;
    public GameObject player;
    public UnityEngine.UI.Text txtHint;
    public UnityEngine.UI.Text txtObjective;
    public GameObject btnBack;

    private GameObject[] mapBlocks;
    private readonly int numOfBlocks = 3;
    private Vector3 screenInWorld;
    private Vector3 scale;
    private Vector3 mapBlockSize;
    private int tutorialLevel;
    private float tutorialTimer;
    private ScoreScript playerScoreScript;
    private int objectCount;

    // Use this for initialization
    void Start () {
        tutorialLevel = -1;
        tutorialTimer = 6.0f;
        txtHint.text = "This is batsy";
        txtObjective.text = "Use W,A,S,D to control her";
        playerScoreScript = player.GetComponent<ScoreScript>();
        // calculate the scale
        mapBlockSize = mapBlock.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 point0 = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));
        Vector3 point1 = Camera.main.ScreenToWorldPoint(new Vector3(mainCam.pixelWidth, mainCam.pixelHeight, 0.0f));
        Vector3 diff = point1 - point0;
        screenInWorld = diff;
        scale = new Vector3(diff.x / mapBlockSize.x, diff.y / mapBlockSize.y, 0.0f);
        // diff / mapBlockSize;

        mapBlocks = new GameObject[numOfBlocks];
        
        mapBlocks[0] = mapBlock;
        mapBlock.transform.SetParent(this.gameObject.transform);
        mapBlock.transform.localScale = scale;
        Debug.Log(scale);
        for (int i = 1; i < numOfBlocks; ++i)
        {
            mapBlocks[i] = Instantiate(mapBlock, new Vector3(0.0f, mapBlockSize.y * scale.y * i, this.gameObject.transform.position.z), Quaternion.identity);
            mapBlocks[i].transform.SetParent(this.gameObject.transform);
            mapBlocks[i].transform.localScale = scale;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < numOfBlocks; ++i)
        {
            mapBlocks[i].transform.position = new Vector3(mapBlocks[i].transform.position.x, mapBlocks[i].transform.position.y - 5.0f * Time.deltaTime, mapBlocks[i].transform.position.z);
            if (mapBlocks[i].transform.position.y < -screenInWorld.y)
            {
                mapBlocks[i].transform.position = new Vector3(mapBlocks[i].transform.position.x, mapBlocks[i].transform.position.y + mapBlockSize.y * scale.y * numOfBlocks, mapBlocks[i].transform.position.z);
                // Destroy all Children
                foreach (Transform child in mapBlocks[i].transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                // Spawn Objects here
                if (tutorialLevel == 0)
                {
                    GameObject newMouse = Instantiate(mouse, mapBlocks[i].transform);
                    newMouse.transform.localPosition = new Vector3(Random.Range(-screenInWorld.x / 2, screenInWorld.x / 2), 0.0f, 0.0f);
                }
                else if(tutorialLevel == 1)
                {
                    // Spawn every object once
                    GameObject obj;
                    switch (objectCount)
                    {
                        // Don't ask me about these positions, I took them from ScrollScript.cs
                        case 0:
                            obj = Instantiate(autoP, mapBlocks[i].transform);
                            obj.transform.localPosition = new Vector3(2.4f, 0.0f, 0.0f);
                            break;
                        case 1:
                            obj = Instantiate(busP, mapBlocks[i].transform);
                            obj.transform.localPosition = new Vector3(2.6f, 0.0f, 0.0f);
                            break;
                        case 2:
                            obj = Instantiate(baumP, mapBlocks[i].transform);
                            obj.transform.localPosition = new Vector3(7.3f, 0.0f, 0.0f);
                            break;
                        case 3:
                            obj = Instantiate(postP, mapBlocks[i].transform);
                            obj.transform.localPosition = new Vector3(7.6f, 0.0f, 0.0f);
                            break;
                        case 4:
                            obj = Instantiate(garbageP, mapBlocks[i].transform);
                            obj.transform.localPosition = new Vector3(6.3f, 0.0f, 0.0f);
                            break;
                        case 5:
                            obj = Instantiate(bushalteP, mapBlocks[i].transform);
                            obj.transform.localPosition = new Vector3(5.8f, 0.0f, 0.0f);
                            break;
                        case 6:
                            obj = Instantiate(hanglampP, mapBlocks[i].transform);
                            obj.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                            break;
                        case 7:
                            obj = Instantiate(opaP, mapBlocks[i].transform);
                            obj.transform.localPosition = new Vector3(Random.Range(-screenInWorld.x/3, screenInWorld.x / 3), 0.0f, 0.0f); // I know this one
                            break;
                        default:
                            break;
                    }
                    objectCount++;
                    if(objectCount == 9)
                    {
                        // spawn firefly swarm
                        Instantiate<GameObject>(fireflySwarm, new Vector3(-screenInWorld.x / 2 - fireflySwarm.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x, 0.0f, 0.0f), Quaternion.identity);
                        txtHint.text = "Control the Fireflies with your mouse, or your eyes*";
                        txtObjective.text = "*if you have a tobii EyeX eyetracker";
                        tutorialTimer = 8.0f;
                        tutorialLevel++;
                    }
                }
            }
        }
        if (tutorialLevel == -1)
        {
            tutorialTimer -= Time.deltaTime;
            if(tutorialTimer <= 0.0f)
            {
                txtHint.text = "Eat mice to increase your score";
                tutorialLevel++;
            }
        }
        else if (tutorialLevel == 0)
        {
            txtObjective.text = "Mice eaten: " + playerScoreScript.miceEaten;

            if (playerScoreScript.miceEaten >= 5)
            {
                txtHint.text = "Avoid these objects";
                txtObjective.text = "";
                objectCount = 0;
                tutorialLevel++;
            }
            
        }
        else if(tutorialLevel == 2)
        { 
            tutorialTimer -= Time.deltaTime;
            if (tutorialTimer <= 0.0f)
            {
                
                txtHint.text = "Well done!";
                // create button to leave to the mainMenu
                btnBack.SetActive(true);
                tutorialLevel++;
            }

        }
        waveMaterial.SetFloat("_yOffset", -mapBlock.transform.position.y / screenInWorld.y + 10.0f); // + 10.0f so modulo won't go negative
    }

    public void btnBack_clicked()
    {
        Debug.Log("done");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
