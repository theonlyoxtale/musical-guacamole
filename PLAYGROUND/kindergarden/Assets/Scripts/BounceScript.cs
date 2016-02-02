using UnityEngine;
using System.Collections;

public class BounceScript : MonoBehaviour {

		//variables
		float lerpTime; //controls the period of time from when the object moves from point a to b
		float currentLerpTime; //this will show where the player is while it's lerping
    float perc = 1f; //shows the percentage that's done
    public float deltaNum = 5.5f;
    Vector3 startPos;
    Vector3 endPos;

    bool firstInput;
    public bool jumped;

    // Update is called once per frame
    void Update () {
			if (Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right")){
				if(perc == 1){
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                jumped = true;
            }
        }
        //setting up startPos
        startPos = gameObject.transform.position;
				if(Input.GetButtonDown("right") && gameObject.transform.position == endPos){
            //set endPos to be set to a new point in 3d space
            endPos = new Vector3(transform.position.x+1,transform.position.y,transform.position.z);
        }
				if(Input.GetButtonDown("left") && gameObject.transform.position == endPos){
            //set endPos to be set to a new point in 3d space
            endPos = new Vector3(transform.position.x-1,transform.position.y,transform.position.z);
        }
				if(Input.GetButtonDown("up") && gameObject.transform.position == endPos){
            //set endPos to be set to a new point in 3d space
            endPos = new Vector3(transform.position.x,transform.position.y,transform.position.z+1);
        }
				if(Input.GetButtonDown("down") && gameObject.transform.position == endPos){
            //set endPos to be set to a new point in 3d space
            endPos = new Vector3(transform.position.x,transform.position.y,transform.position.z-1);
        }
				if(firstInput == true){
            //updates the Time for whatever FPS the device runs
            currentLerpTime += Time.deltaTime * deltaNum;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, perc);
					if(perc > 0.8){
                perc = 1;
            }
					if(Mathf.Round(perc) == 1){
                jumped = false;
            }
				}
    }

}
