using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 1f;
    public float jumpReloadTime = 3f; 

    private Rigidbody rb;
    private bool canJump = true;

    public int health;
    public BarData healthBar;
    private int healthValue = 100;
    public int gems;


    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] private GameObject gem1;
    [SerializeField] private GameObject gem2;
    [SerializeField] private GameObject gem3;
    [SerializeField] private GameObject gem4;
    [SerializeField] private GameObject gem5;


    private void DecreaseStats()
    {
        healthBar.SetHealth(health);

        //hygieneValue -= decrHygieneRate;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthBar.SetMaxHealth(healthValue);

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

        DecreaseStats();
        healthText.text = health.ToString("");

        if (gems > 0)
        {
            if (gems == 1)
            {
                gem1.gameObject.SetActive(true);
            }
            if (gems == 2)
            {
                gem2.gameObject.SetActive(true);
            }
            if (gems == 3)
            {
                gem3.gameObject.SetActive(true);
            }
            if (gems == 4)
            {
                gem4.gameObject.SetActive(true);
            }
            if (gems == 5)
            {
                gem5.gameObject.SetActive(true);
            }


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

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Player collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<enemyMovement>().damage);

            //Debug.Log("Player Health: " + health);
        }
        else if (collision.gameObject.CompareTag("Plants"))
        {
            TakeDamage(6);
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            TakeDamage(2);
        }
        else if (collision.gameObject.CompareTag("Poison"))
        {
            TakeDamage(8);
        }
        else if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gems++;
        }
    }
    void TakeDamage(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            //Destroy(gameObject);
        }
    }


}
