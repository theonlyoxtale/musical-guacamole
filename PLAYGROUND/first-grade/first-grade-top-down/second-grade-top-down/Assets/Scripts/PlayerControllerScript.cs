using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerScript : MonoBehaviour
{
    //Player variables
    public float moveSpeed = 3f;
    public Camera currentCam;

    //System variables

    // Update is called once per frame
    void Update()
    {
        //controls Player movement
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed);

        //mouse Look script 
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        float dist;
        if (plane.Raycast (ray, out dist)) {
            transform.LookAt (ray.GetPoint(dist));
        }
    }
    }
