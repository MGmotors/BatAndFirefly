using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour {
    public GameObject mapPrefab, autoP, busP, baumP, postP, bushalteP, garbageP, highlampP, hanglampP;
    public List<GameObject> mapBlocks;

    // Use this for initialization
    void Start () {
        mapBlocks = new List<GameObject>();
        Vector2 vSize = new Vector2(0, 0);
        for(int i = 0; i< 4; i++)
        {
            GameObject mapBlock = GameObject.Instantiate<GameObject>(mapPrefab);
            mapBlock.transform.position = new Vector3(vSize.x, vSize.y, 1);
            SpriteRenderer sr = mapBlock.GetComponent<SpriteRenderer>();
            vSize = new Vector2(vSize.x, vSize.y + 108f/10);
            mapBlocks.Add(mapBlock);
        }
	}

    // Update is called once per frame
    void Update() {
        mapBlocks[0].transform.position = new Vector3(mapBlocks[0].transform.position.x, mapBlocks[0].transform.position.y - 5 * Time.deltaTime);
        mapBlocks[1].transform.position = new Vector3(mapBlocks[1].transform.position.x, mapBlocks[1].transform.position.y - 5 * Time.deltaTime);
        mapBlocks[2].transform.position = new Vector3(mapBlocks[2].transform.position.x, mapBlocks[2].transform.position.y - 5 * Time.deltaTime);
        mapBlocks[3].transform.position = new Vector3(mapBlocks[3].transform.position.x, mapBlocks[3].transform.position.y - 5 * Time.deltaTime);
        
        if(mapBlocks[0].transform.position.y <= (-12))
        {
            GameObject toBeDeleted = mapBlocks[0];
            mapBlocks.RemoveAt(0);
            Destroy(toBeDeleted);
            GameObject mapBlock = GameObject.Instantiate<GameObject>(mapPrefab);
            mapBlock.transform.position = new Vector3(mapBlocks[2].transform.position.x, mapBlocks[2].transform.position.y + 108f/10, 1);
            mapBlocks.Add(mapBlock);
            SpawnObject(3);
        }
    }

    void SpawnObject(int runs)
    {
        int counter = 0;
        int maxCount = 0;
        List<GameObject> spawnedObjects = new List<GameObject>();
        bool space = false;
        GameObject obj = mapPrefab;
        while (counter < runs)
        {
            space = false;
            while (!space)
            {
                int r = Random.Range(0, 7);
                switch (r)
                {
                    case 0:
                        obj = GameObject.Instantiate<GameObject>(autoP);
                        spawnedObjects.Add(SetObj(obj, 6.5f));
                        break;
                    case 1:
                        obj = GameObject.Instantiate<GameObject>(busP);
                        spawnedObjects.Add(SetObj(obj, 2.6f));
                        break;
                    case 2:
                        obj = GameObject.Instantiate<GameObject>(baumP);
                        spawnedObjects.Add(SetObj(obj, 7.3f));
                        break;
                    case 3:
                        obj = GameObject.Instantiate<GameObject>(postP);
                        spawnedObjects.Add(SetObj(obj, 7.6f));
                        break;
                    case 4:
                        obj = GameObject.Instantiate<GameObject>(garbageP);
                        spawnedObjects.Add(SetObj(obj, 6.3f));
                        break;
                    case 5:
                        obj = GameObject.Instantiate<GameObject>(bushalteP);
                        spawnedObjects.Add(SetObj(obj, 5.8f));
                        break;
                    case 6:
                        obj = GameObject.Instantiate<GameObject>(highlampP);
                        spawnedObjects.Add(SetObj(obj, 4.9f));
                        break;
                    case 7:
                        obj = GameObject.Instantiate<GameObject>(hanglampP);
                        spawnedObjects.Add(SetObj(obj, 0.0f));
                        break;
                    default: break;
                }

                for (int i = 0; i < spawnedObjects.Count - 1; i++)
                {
                    Debug.Log("i : " + i + "| Count: " + spawnedObjects.Count);
                    if (!spawnedObjects[i].GetComponent<SpriteRenderer>().bounds.Intersects(obj.GetComponent<SpriteRenderer>().bounds))
                    {
                        if (i == spawnedObjects.Count - 2)
                        {
                            space = true;
                            counter++;
                        }
                    }
                    else
                    {
                        Destroy(obj);
                        Debug.Log("No Space");
                        break;
                    }
                }
                maxCount++;
                if (maxCount > 5)
                    return;

            }
        }
    }

    GameObject SetObj(GameObject ob, float xy)
    {
        if (xy == 4.9f || xy == 6.3f)
        {
            ob.transform.SetParent(mapBlocks[3].transform);
            int rand = Random.Range(0, 2);
            float sizeY = ob.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
            if (rand == 0)
            {
                ob.transform.localPosition = new Vector3(-xy, Random.Range(-5.4f + sizeY, 5.4f - sizeY));
                ob.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (rand == 1)
                ob.transform.localPosition = new Vector3(xy, Random.Range(-5.4f + sizeY, 5.4f - sizeY));
            //ob.transform.localScale = new Vector3(.1f, .1f, 1);
        }
        else
        {
            ob.transform.SetParent(mapBlocks[3].transform);
            int rand = Random.Range(0, 2);
            float sizeY = ob.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
            if (rand == 0)
                ob.transform.localPosition = new Vector3(-xy, Random.Range(-5.4f + sizeY, 5.4f - sizeY));
            else if (rand == 1)
                ob.transform.localPosition = new Vector3(xy, Random.Range(-5.4f + sizeY, 5.4f - sizeY));
            //ob.transform.localScale = new Vector3(.1f, .1f, .1f);
        }
        return ob;
    }
}
