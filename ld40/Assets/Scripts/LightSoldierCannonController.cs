using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSoldierCannonController : MonoBehaviour {

    public Transform playerTransform;
    public GameObject playerGameObject;
    public Transform lightSoldierCannon;
    public Transform lightBall;
    private Transform[] lightCannonSoldiers;
    private bool shouldSpawn = false;

	// Use this for initialization
	void Start () {
        lightCannonSoldiers = new Transform[100];
        
            lightCannonSoldiers[0] = Instantiate(lightSoldierCannon, new Vector3(Random.Range(playerTransform.position.x - 10f, playerTransform.position.x + 10f), -3f, 0.0f), Quaternion.identity);
            lightCannonSoldiers[0].GetComponent<Cannon>().InitCannon(lightBall, playerTransform, playerGameObject);
        
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        
        for (int i = 0; i < lightCannonSoldiers.Length; i++)
        {
            if (lightCannonSoldiers[i] != null)
            {
                if (Mathf.Abs(playerTransform.position.x - lightCannonSoldiers[i].GetComponent<Cannon>().transform.position.x) > 30f)
                {
                    lightCannonSoldiers[i].GetComponent<Cannon>().destroy();
                    lightCannonSoldiers[i] = Instantiate(lightSoldierCannon, new Vector3(Random.Range(playerTransform.position.x - 10f, playerTransform.position. x + 10f), -3f, 0.0f), Quaternion.identity);
                    lightCannonSoldiers[i].GetComponent<Cannon>().InitCannon(lightBall, playerTransform, playerGameObject);
                }
            }
        }
        


        for (int i = 0; i < lightCannonSoldiers.Length; i++)
        {
            if(lightCannonSoldiers[i] != null)
            {
                lightCannonSoldiers[i].GetComponent<Cannon>().updateCannon();
            }
        }

        if (shouldSpawn)
        {
            for (int i = 0; i < lightCannonSoldiers.Length; i++)
            {
                if (lightCannonSoldiers[i] == null)
                {
                    lightCannonSoldiers[i] = Instantiate(lightSoldierCannon, new Vector3(Random.Range(playerTransform.position.x - 10f, playerTransform.position.x + 10f), -3f, 0.0f), Quaternion.identity);
                    lightCannonSoldiers[i].GetComponent<Cannon>().InitCannon(lightBall, playerTransform, playerGameObject);
                    shouldSpawn = false;
                    break;
                
                }
            }
        }
    }

    public void spawnCannon()
    {
        shouldSpawn = true;
    }
}
