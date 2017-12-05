using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    private Transform lightBall;
    private bool enable = true;
    private Transform lightBallInstance;
    private Transform lightBallTarget;
    private GameObject playerGameObject;

    public void InitCannon(Transform lightBall, Transform lightBallTarget, GameObject playerGameObject)
    {
        this.lightBall = lightBall;
        this.lightBallTarget = lightBallTarget;
        this.playerGameObject = playerGameObject;
    }

    // Update is called once per frame
    public void updateCannon () {
        

        if (enable)
        {
            
                lightBallInstance = Instantiate(lightBall, new Vector3(transform.position.x + 1, transform.position.y + 0.9f, 0.0f), Quaternion.identity);
                lightBallInstance.GetComponent<LightBall>().InitBall(lightBallInstance.GetChild(0), lightBallTarget, playerGameObject);
                enable = false;
            
            
        }
        else
        {
            if (lightBallInstance != null)
                lightBallInstance.GetComponent<LightBall>().updateBall();
            else
                enable = true;
            
                    
        }
        
    }
    public void destroy()
    {
        enable = false;
        
        if(lightBallInstance != null)
            lightBallInstance.GetComponent<LightBall>().destroy();
        Destroy(this.gameObject);
    }
}
