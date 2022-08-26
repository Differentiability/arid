using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 10f;
    public float Sensitivity = 4000f;

    CharacterController playerController;

    float xRotation = 0f;
    float yRotation = 0f;

    Transform cameraTransform;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerController = GetComponent<CharacterController>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = (transform.right * horizontalMovement + 
                                transform.forward * verticalMovement).normalized;

        playerController.Move(moveDirection * MovementSpeed * Time.deltaTime);

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Sensitivity;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
