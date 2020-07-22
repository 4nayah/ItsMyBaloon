using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float smooth = 5.0f;
    public Vector3 offset;
    public Vector3 cameraControl;
    public Vector3 cameraControlRotation;
    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;

    void Start()
    {

    }

    void LateUpdate()
    {

      var Ballon = GameObject.Find("Ballon");
      var Respawner = GameObject.Find("RespawnCollider");


      desiredPosition = Ballon.transform.position + offset;
      smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
      transform.position = smoothedPosition;

      // if(transform.position.z <= -17)
      // {
      //
      //   // CAMERA A BLOQUER
      //
      // }

      // transform.LookAt(Ballon.transform);
      // transform.position = Vector3.Lerp (transform.position, Ballon.transform.position,Time.deltaTime * smooth);

    }
}
