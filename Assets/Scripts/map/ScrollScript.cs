using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public GameObject mapPrefab, autoP, busP, baumP, postP, bushalteP, garbageP, highlampP, hanglampP, opaP, puHealthP, puWaveP, puFireflyP, obj;
    public Material waveMaterial;
    public List<GameObject> mapBlocks;
    public Vector3 scale;
 
    public float speed;
	public float maxSpeed;
	public float speedIncreasePerSecond;
    public bool newMap;


    // Use this for initialization
    void Start()
    {
        obj = new GameObject();
        newMap = false;
        Vector3 nullP = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 endP = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 1));
        float width = endP.x - nullP.x;
        float height = endP.y - nullP.y;
        scale = new Vector3(width / mapPrefab.GetComponent<SpriteRenderer>().bounds.size.x, height / mapPrefab.GetComponent<SpriteRenderer>().bounds.size.y, 1.0f);
        mapBlocks = new List<GameObject>();
        Vector2 vSize = new Vector2(0, 0);
        for (int i = 0; i < 4; i++)
        {
            GameObject mapBlock = GameObject.Instantiate<GameObject>(mapPrefab);
            mapBlock.transform.localScale = scale;
            mapBlock.transform.position = new Vector3(vSize.x, vSize.y, 1);
            vSize = new Vector2(vSize.x, vSize.y + height);
            mapBlocks.Add(mapBlock);
        }
        float inScreen = Camera.main.WorldToScreenPoint(mapBlocks[0].transform.position).y;
        inScreen /= (float) Camera.main.pixelHeight;
        waveMaterial.SetFloat("_yOffset", -inScreen + 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
		if (speed < maxSpeed) {
			speed += speedIncreasePerSecond * Time.deltaTime;
		}
		mapBlocks[0].transform.position = new Vector3(mapBlocks[0].transform.position.x, mapBlocks[0].transform.position.y - speed * Time.deltaTime);
        mapBlocks[1].transform.position = new Vector3(mapBlocks[1].transform.position.x, mapBlocks[1].transform.position.y - speed * Time.deltaTime);
        mapBlocks[2].transform.position = new Vector3(mapBlocks[2].transform.position.x, mapBlocks[2].transform.position.y - speed * Time.deltaTime);
        mapBlocks[3].transform.position = new Vector3(mapBlocks[3].transform.position.x, mapBlocks[3].transform.position.y - speed * Time.deltaTime);

        Vector3 nullP = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 endP = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 1));
        float height = endP.y - nullP.y;


        if(newMap == true)
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnObject();
            }
            newMap = false;
        }
        if (mapBlocks[0].transform.position.y <= (-12))
        {
            GameObject toBeDeleted = mapBlocks[0];
            mapBlocks.RemoveAt(0);
            Destroy(toBeDeleted);
            GameObject mapBlock = GameObject.Instantiate<GameObject>(mapPrefab);
            mapBlock.transform.localScale = scale;
            mapBlock.transform.position = new Vector3(mapBlocks[2].transform.position.x, mapBlocks[2].transform.position.y + height, 1);
            mapBlocks.Add(mapBlock);
            newMap = true;
        }

        float inScreen = Camera.main.WorldToScreenPoint(mapBlocks[0].transform.position).y;
        inScreen /= (float)Camera.main.pixelHeight;
        waveMaterial.SetFloat("_yOffset", 50.0f - inScreen + 0.5f);
    }

    void SpawnObject()
    {
        bool space = false;
        Vector3 testVec;
        Bounds b;
        int r = Random.Range(0, 9);
        switch (r)
        {
            case 0:
                testVec = TryObjPos(autoP, 2.4f);
                testVec.Scale(scale);
                b = new Bounds(testVec, autoP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(autoP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;

            case 1:
                testVec = TryObjPos(busP, 2.6f);
                testVec.Scale(scale);
                b = new Bounds(testVec, busP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(busP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;

            case 2:
                testVec = TryObjPos(baumP, 7.3f);
                testVec.Scale(scale);
                b = new Bounds(testVec, baumP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(baumP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;

            case 3:
                testVec = TryObjPos(postP, 7.6f);
                testVec.Scale(scale);
                b = new Bounds(testVec, postP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(postP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;

            case 4:
                testVec = TryObjPos(garbageP, 6.3f);
                testVec.Scale(scale);
                b = new Bounds(testVec, garbageP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(garbageP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;

            case 5:
                testVec = TryObjPos(bushalteP, 5.8f);
                testVec.Scale(scale);
                b = new Bounds(testVec, bushalteP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(bushalteP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;

            case 6:
                SpawnPowerUps();
                break;
            case 7:
                testVec = TryObjPos(hanglampP, 0.0f);
                b = new Bounds(testVec, hanglampP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(hanglampP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    obj.name = "ignoreCheck";
                }
                break;
            case 8:
                testVec = TryObjPos(opaP, Random.Range(-9.6f, 9.6f));
                testVec.Scale(scale);
                b = new Bounds(testVec, opaP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(opaP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;
            default:
                break;
        }
        if(obj.transform.position.x < 0)
        {
            obj.GetComponent<SpriteRenderer>().flipX = true;
        }
        return;
    }

    void SpawnPowerUps()
    {
        bool space = false;
        Vector3 testVec;
        Bounds b;
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                testVec = TryObjPos(puWaveP, Random.Range(-4.3f,4.3f));
                testVec.Scale(scale);
                b = new Bounds(testVec, puWaveP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if(space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(puWaveP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;
            case 1:
                int r = Random.Range(0, 2);
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>().currentHeards >= 3)
                {
                    testVec = TryObjPos(puHealthP, Random.Range(-4.3f, 4.3f));
                    testVec.Scale(scale);
                    b = new Bounds(testVec, puHealthP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                    space = TestForCol(testVec, b);
                    if (space == true)
                    {
                        obj = GameObject.Instantiate<GameObject>(puHealthP);
                        obj.transform.position = testVec;
                        obj.transform.SetParent(mapBlocks[3].transform);
                    }
                }
                else if(r == 0)
                {
                    testVec = TryObjPos(puWaveP, Random.Range(-4.3f, 4.3f));
                    testVec.Scale(scale);
                    b = new Bounds(testVec, puWaveP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                    space = TestForCol(testVec, b);
                    if (space == true)
                    {
                        obj = GameObject.Instantiate<GameObject>(puWaveP);
                        obj.transform.position = testVec;
                        obj.transform.SetParent(mapBlocks[3].transform);
                    } 
                }
                else if(r == 1)
                {
                    testVec = TryObjPos(puWaveP, Random.Range(-4.3f, 4.3f));
                    testVec.Scale(scale);
                    b = new Bounds(testVec, puWaveP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                    space = TestForCol(testVec, b);
                    if (space == true)
                    {
                        obj = GameObject.Instantiate<GameObject>(puWaveP);
                        obj.transform.position = testVec;
                        obj.transform.SetParent(mapBlocks[3].transform);
                    }
                }
                break;
            case 2:
                testVec = TryObjPos(puFireflyP, Random.Range(-4.3f,4.3f));
                testVec.Scale(scale);
                b = new Bounds(testVec, puFireflyP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                if (space == true)
                {
                    obj = GameObject.Instantiate<GameObject>(puFireflyP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                }
                break;
            default:
                break;
        }
    }

    Vector3 TryObjPos(GameObject prefab, float xy)
    {
        Vector3 actMapM = mapBlocks[3].transform.position;
        int rand = Random.Range(0, 2);
        float sizeY = prefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        Vector3 returnVal;
        if (rand == 0)
        {
            returnVal = new Vector3(-xy, Random.Range(actMapM.y-5.4f + sizeY, actMapM.y + 5.4f - sizeY));
        }
        else
            returnVal = new Vector3(xy, Random.Range(actMapM.y - 5.4f + sizeY, actMapM.y + 5.4f - sizeY));
        return returnVal;
    }

    bool TestForCol(Vector3 pos, Bounds bounds)
    {
        if (mapBlocks[3].transform.childCount == 0)
        {
            return true;
        }
        else
        {
            int i = 0;
            bool x = false;
            foreach (Transform child in mapBlocks[3].transform)
            {
                if (child.name == "ignoreCheck" && bounds.size != child.GetComponent<SpriteRenderer>().bounds.size)
                {
                    i++;
                    x = true;
                }
                else
                {
                    if (child.GetComponent<SpriteRenderer>().bounds.Intersects(bounds))
                    {
                        x = false;
                    }
                    else
                    {
                        if (i == mapBlocks[3].transform.childCount - 1)
                        {
                            x = true;
                        }
                        i++;
                    }
                }
            }
            return x;
        }
    }
}

