using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	// Use this for initialization
	public void InitHouse() {
        transform.GetChild((int)Random.Range(0, 3)).GetComponent<SpriteRenderer>().enabled = true;
	}

}
