using UnityEngine;
using System.Collections;

public class InfiniteCorridor : MonoBehaviour {

    public Transform player;    
    public int numberOfActivePrefabs = 3;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;

    private int nbPrefabDestroyed = 1;
    private Object[] prefabs;
    private GameObject[] activePrefabs;

	// Use this for initialization
	void Start () {
        GameObject corridor = GameObject.Find("Corridor");
        if (corridor != null)
        {
            Destroy(corridor);
        }
        prefabs = new Object[5];
        prefabs[0] = prefab1;
        prefabs[1] = prefab2;
        prefabs[2] = prefab3;
        prefabs[3] = prefab4;
        prefabs[4] = prefab5;
        buildNewLevel();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.position.x > 50 * nbPrefabDestroyed)
        {            
            Vector3 pos = new Vector3(50 * (numberOfActivePrefabs - 1 + nbPrefabDestroyed), 0, 0);
            GameObject newPrefab = (GameObject)Instantiate(getPrefab(), pos, Quaternion.identity);
            Destroy(activePrefabs[0]);
            for (var i = 0; i < numberOfActivePrefabs - 1; i++)
            {
                activePrefabs[i] = activePrefabs[i+1];
            }
            activePrefabs[numberOfActivePrefabs - 1] = newPrefab;
            nbPrefabDestroyed++;
        }
	}

    public void buildNewLevel()
    {
        if (activePrefabs != null)
        {
            for (var i = 0; i < numberOfActivePrefabs; i++)
            {
                Destroy(activePrefabs[i]);
            }
        } else
        {
            activePrefabs = new GameObject[numberOfActivePrefabs];
        }
        for (int i = 0; i < numberOfActivePrefabs; i++)
        {
            Vector3 pos = new Vector3(50 * i, 0, 0);
            activePrefabs[i] = (GameObject)Instantiate(getPrefab(), pos, Quaternion.identity);
        }
		nbPrefabDestroyed = 1;
    }

    private Object getPrefab()
    {
        return prefabs[Random.Range(0, 4)];
    }
}
