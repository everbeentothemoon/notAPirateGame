using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 10f;
    public float jumpReloadTime = 3f; 

    private Rigidbody rb;
    private bool canJump = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += horizontalInput * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            canJump = false; 
            StartCoroutine(ReloadJump());
        }
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private IEnumerator ReloadJump()
    {
        yield return new WaitForSeconds(jumpReloadTime);
        canJump = true;
    }

}
