using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public GameObject mapPrefab, autoP, busP, baumP, postP, bushalteP, garbageP, highlampP, hanglampP;
    public List<GameObject> mapBlocks;

    // Use this for initialization
    void Start()
    {
        mapBlocks = new List<GameObject>();
        Vector2 vSize = new Vector2(0, 0);
        for (int i = 0; i < 4; i++)
        {
            GameObject mapBlock = GameObject.Instantiate<GameObject>(mapPrefab);
            mapBlock.transform.position = new Vector3(vSize.x, vSize.y, 1);
            SpriteRenderer sr = mapBlock.GetComponent<SpriteRenderer>();
            vSize = new Vector2(vSize.x, vSize.y + 108f / 10);
            mapBlocks.Add(mapBlock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        mapBlocks[0].transform.position = new Vector3(mapBlocks[0].transform.position.x, mapBlocks[0].transform.position.y - 5 * Time.deltaTime);
        mapBlocks[1].transform.position = new Vector3(mapBlocks[1].transform.position.x, mapBlocks[1].transform.position.y - 5 * Time.deltaTime);
        mapBlocks[2].transform.position = new Vector3(mapBlocks[2].transform.position.x, mapBlocks[2].transform.position.y - 5 * Time.deltaTime);
        mapBlocks[3].transform.position = new Vector3(mapBlocks[3].transform.position.x, mapBlocks[3].transform.position.y - 5 * Time.deltaTime);

        if (mapBlocks[0].transform.position.y <= (-12))
        {
            GameObject toBeDeleted = mapBlocks[0];
            mapBlocks.RemoveAt(0);
            Destroy(toBeDeleted);
            GameObject mapBlock = GameObject.Instantiate<GameObject>(mapPrefab);
            mapBlock.transform.position = new Vector3(mapBlocks[2].transform.position.x, mapBlocks[2].transform.position.y + 108f / 10, 1);
            mapBlocks.Add(mapBlock);
            for (int i = 0; i < 5; i++)
            {
                SpawnObject();
            }
            
        }
    }

    void SpawnObject()
    {
        List<GameObject> spawnedObjects = new List<GameObject>();
        bool space = false;
        Vector3 testVec;
        Bounds b;

        int r = Random.Range(0, 7);
        switch (r)
        {
            case 0:
                testVec = TryObjPos(autoP, 6.5f);
                b = new Bounds(testVec, autoP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                Debug.Log(space + " " +b+ " "+ testVec);
                if (space == true)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(autoP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    return;
                }
                break;

            case 1:
                testVec = TryObjPos(busP, 2.6f);
                b = new Bounds(testVec, busP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                Debug.Log(space + " " +b+ " "+ testVec);
                if (space == true)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(busP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    return;
                }
                break;

            case 2:
                testVec = TryObjPos(baumP, 7.3f);
                b = new Bounds(testVec, baumP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                Debug.Log(space + " " +b+ " "+ testVec);
                if (space == true)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(baumP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    return;
                }
                break;

            case 3:
                testVec = TryObjPos(postP, 7.6f);
                b = new Bounds(testVec, postP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                Debug.Log(space + " " +b+ " "+ testVec);
                if (space == true)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(postP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    return;
                }
                break;

            case 4:
                testVec = TryObjPos(garbageP, 6.3f);
                b = new Bounds(testVec, garbageP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                Debug.Log(space + " " +b+ " "+ testVec);
                if (space == true)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(garbageP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    return;
                }
                break;

            case 5:
                testVec = TryObjPos(bushalteP, 5.8f);
                b = new Bounds(testVec, bushalteP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                Debug.Log(space + " " +b+ " "+ testVec);
                if (space == true)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(bushalteP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    return;
                }
                break;

            case 6:
                testVec = TryObjPos(highlampP, 4.9f);
                b = new Bounds(testVec, highlampP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                Debug.Log(space + " " +b+ " "+ testVec);
                if (space == true)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(highlampP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    return;
                }
                break;

            case 7:
                testVec = TryObjPos(hanglampP, 0.0f);
                b = new Bounds(testVec, highlampP.GetComponent<SpriteRenderer>().sprite.bounds.size);
                space = TestForCol(testVec, b);
                Debug.Log(space + " " +b+ " "+ testVec);
                if (space == true)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(hanglampP);
                    obj.transform.position = testVec;
                    obj.transform.SetParent(mapBlocks[3].transform);
                    return;
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
            Debug.Log(mapBlocks[3].transform.childCount);
            foreach (Transform child in mapBlocks[3].transform)
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
            return x;
        }
    }
}

