/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float range = 50f;
    public float minWaitTime = 5f;
    public float maxWaitTime = 20f;
    public float playerFollowDistance = 3f;
    public float playerDetectionRange = 10f;

    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    private GameObject player;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isWaiting = false;
    private float waitTimer = 0f;
    private float currentWaitTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MoveToRandomPosition();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= playerDetectionRange)
        {
            if (distanceToPlayer > playerFollowDistance)
            {
                MoveTowardsPlayer();
                return;
            }
            else
            {
                StopMoving();
            }
        }

        if (isMoving)
        {
            Vector3 movementDirection = targetPosition - transform.position;

            transform.Translate(movementDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                StartWaiting();
            }
        }
        else if (isWaiting)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= currentWaitTime)
            {
                MoveToRandomPosition();
            }
        }
    }

    private void MoveToRandomPosition()
    {
        targetPosition = new Vector3(
            UnityEngine.Random.Range(transform.position.x - range, transform.position.x + range),
            transform.position.y,
            UnityEngine.Random.Range(transform.position.z - range, transform.position.z + range)
        );

        Vector3 lookDirection = targetPosition - transform.position;
        lookDirection.y = 0f;
        transform.rotation = Quaternion.LookRotation(lookDirection);

        isMoving = true;
        isWaiting = false;
    }

    private void StartWaiting()
    {
        currentWaitTime = UnityEngine.Random.Range(minWaitTime, maxWaitTime);
        waitTimer = 0f;
        isWaiting = true;
    }

    private void MoveTowardsPlayer()
    {
        Vector3 movementDirection = player.transform.position - transform.position;
        float rotationSpeed = 5f;

        transform.Translate(movementDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (movementDirection.magnitude > 0.1f) // Check if there's significant movement
        {
            Vector3 lookDirection = player.transform.position - transform.position;
            lookDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        isMoving = true;
        isWaiting = false;
    }

    private void StopMoving()
    {
        isMoving = false;
        isWaiting = true;
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float speed;
    Transform player;

    public int health;
    public int damage;
    //public EnemySpawner spawner;



    //public EnemySpawner enemySpawner;

    // Start is called before the first frame update
    public int enemieskilled = 0;
    void Start()
    {
        player = FindObjectOfType<angelScript>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Player collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<BulletScript>().damage);
            Debug.Log("hit");
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            //TakeDamage(other.GetComponent<BulletScript>().damage);
        }
    }*/
    public event System.Action OnEnemyDeath;
    void TakeDamage(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            enemieskilled++;
            //Debug.Log(enemieskilled);
            Destroy(gameObject);

        }

    }
}
