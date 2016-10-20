using UnityEngine;
using System.Collections;

public class InfiniteCorridor : MonoBehaviour {

    public Transform player;
    public GameObject prefab;
    public int nbPrefab;
    private int nbPrefabDestroyed = 1;
    private GameObject[] prefabs;

	// Use this for initialization
	void Start () {
        GameObject corridor = GameObject.Find("Corridor");
        if (corridor != null)
        {
            Destroy(corridor);
        }
        prefabs = new GameObject[nbPrefab];
        for (int i = 0; i < nbPrefab; i++)
        {
            Vector3 pos = new Vector3(50 * i, 0, 0);
            prefabs[i] = (GameObject) Instantiate(prefab, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (player.position.x > 50 * nbPrefabDestroyed)
        {            
            Vector3 pos = new Vector3(50 * (nbPrefab - 1 + nbPrefabDestroyed), 0, 0);
            GameObject newPrefab = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
            Destroy(prefabs[0]);
            for (var i = 0; i < nbPrefab - 1; i++)
            {
                prefabs[i] = prefabs[i+1];
            }            
            prefabs[nbPrefab-1] = newPrefab;
            nbPrefabDestroyed++;
        }
	}
}
