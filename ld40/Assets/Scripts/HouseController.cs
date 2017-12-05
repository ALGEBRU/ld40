using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour {

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform house;
    private Transform[] houses;

	// Use this for initialization
	void Start () {
        houses = new Transform[7];
        float totalSpacing = 0.0f;
        for(int i = 0; i < houses.Length; i++)
        {
            houses[i] = Instantiate(house, new Vector3((playerTransform.position.x - 15f) + totalSpacing, -2.55f, 0.0f), Quaternion.identity);
            houses[i].GetComponent<House>().InitHouse();
            totalSpacing += 4.5f;
            if (totalSpacing > 30.0f)
                break;
        }

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        for(int i = 0; i < houses.Length; i++)
        {
            if(houses[i].position.x < playerTransform.position.x - 19.5f)
            {
                float oldHouseX = houses[i].position.x;
                Destroy(houses[i].gameObject);
                houses[i] = Instantiate(house, new Vector3(oldHouseX + 31.5f, -2.55f, 0.0f), Quaternion.identity);
                houses[i].GetComponent<House>().InitHouse();
            } else if (houses[i].position.x > playerTransform.position.x + 12f)
            {
                float oldHouseX = houses[i].position.x;
                Destroy(houses[i].gameObject);
                houses[i] = Instantiate(house, new Vector3(oldHouseX - 31.5f, -2.55f, 0.0f), Quaternion.identity);
                houses[i].GetComponent<House>().InitHouse();
            }
        }


    }

}
