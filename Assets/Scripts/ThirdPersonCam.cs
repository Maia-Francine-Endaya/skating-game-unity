using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
  [Header("References")]
  public Transform orientation;
  public Transform playerObj;
  public Transform player_body;
  public Rigidbody rb;

  public float rotationSpd;

  private void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  private void Update()
  {
    Vector3 viewDir = playerObj.position - new Vector3(transform.position.x, playerObj.position.y, transform.position.z);
    orientation.forward = viewDir.normalized;

    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

    if (inputDir != Vector3.zero)
    {
      playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpd);
    }
  }
}
