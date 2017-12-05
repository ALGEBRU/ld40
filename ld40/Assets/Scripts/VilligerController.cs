using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilligerController : MonoBehaviour {

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform villager;

    private Transform[] villigers;

	// Use this for initialization
	void Start () {
        villigers = new Transform[10];
        for(int i = 0; i < villigers.Length; i++)
        {
            villigers[i] = Instantiate(villager, new Vector3(Random.Range(playerTransform.position.x - 15f, playerTransform.position.x + 15f), -4f, 0.0f), Quaternion.identity);
            villigers[i].GetComponent<Villiger>().InitVillager(playerTransform);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		for(int i = 0; i < villigers.Length; i++)
        {
            if(villigers[i] != null)
            {
                if (villigers[i].position.y < -10 || Mathf.Abs(villigers[i].position.x - playerTransform.position.x) > 30f)
                {
                    villigers[i].GetComponent<Villiger>().destroy();
                    villigers[i] = null;
                    if (Random.Range(0.0f, 1.0f) >= 0.5f)
                    {
                        villigers[i] = Instantiate(villager, new Vector3(Random.Range(playerTransform.position.x - 15f, playerTransform.position.x - 9.5f), -4f, 0.0f), Quaternion.identity);
                        villigers[i].GetComponent<Villiger>().InitVillager(playerTransform);
                    }
                    else
                    {
                        villigers[i] = Instantiate(villager, new Vector3(Random.Range(playerTransform.position.x + 9.5f, playerTransform.position.x + 15f), -4f, 0.0f), Quaternion.identity);
                        villigers[i].GetComponent<Villiger>().InitVillager(playerTransform);
                    }
                }
            }
            
        }

        for(int i = 0; i < villigers.Length; i++)
        {
            if(villigers[i] != null)
            {
                if (villigers[i].GetComponent<Villiger>().updateVillager())
                {
                    Destroy(villigers[i].gameObject);
                    villigers[i] = null;
                }
                    
            }
            else
            {
                if(Random.Range(0.0f, 1.0f) >= 0.5f)
                {
                    villigers[i] = Instantiate(villager, new Vector3(Random.Range(playerTransform.position.x - 15f, playerTransform.position.x - 9.5f), -4f, 0.0f), Quaternion.identity);
                    villigers[i].GetComponent<Villiger>().InitVillager(playerTransform);
                }
                else
                {
                    villigers[i] = Instantiate(villager, new Vector3(Random.Range(playerTransform.position.x + 9.5f, playerTransform.position.x + 15f), -4f, 0.0f), Quaternion.identity);
                    villigers[i].GetComponent<Villiger>().InitVillager(playerTransform);
                }
                
            }
        }
	}
}
