using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerScript : MonoBehaviour
{
    //Player variables
    public float walkingSpeed_f = 4f;
    public float runSpeed_f = 8f;
    public float rotationSpeed_f = 450f;

    //System variables
    private Quaternion targetRotation;

    //Component variables
    private CharacterController controller;

    void Start(){
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        ControlMouse();
        //ControlWASD();
    }

    void ControlMouse()
    {
      //Getting the mouse position
      
      Vector3 playerInput_v = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
      // setting up player movement
      Vector3 motion = playerInput_v;
      motion *= (Mathf.Abs(playerInput_v.x) == 1 && Mathf.Abs(playerInput_v.z) == 1) ? .7f : 1;
      motion *= (Input.GetButton("Run")?runSpeed_f:walkingSpeed_f);
      motion += Vector3.up * -8;
      controller.Move(motion * Time.deltaTime);
    }

    void ControlWASD(){
      Vector3 playerInput_v = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

      if(playerInput_v != Vector3.zero){
          //takes in a direction and makes the player look in that direction
          targetRotation = Quaternion.LookRotation(playerInput_v);
          transform.eulerAngles = Vector3.up*Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed_f*Time.deltaTime);
      }

      // setting up player movement
      Vector3 motion = playerInput_v;
      motion *= (Mathf.Abs(playerInput_v.x) == 1 && Mathf.Abs(playerInput_v.z) == 1) ? .7f : 1;
      motion *= (Input.GetButton("Run")?runSpeed_f:walkingSpeed_f);
      motion += Vector3.up * -8;
      controller.Move(motion * Time.deltaTime);
    }
}
