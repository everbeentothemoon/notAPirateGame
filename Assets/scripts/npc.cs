using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public Transform player;
    public Vector3 fixedUpDirection = Vector3.up;
    public float activationDistance = 5f;
    public GameObject mission;


    // Start is called before the first frame update
    void Start()
    {
        mission.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mission != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

                if (distanceToPlayer <= activationDistance)
                {
                    mission.SetActive(true);
                }

                if (distanceToPlayer >= activationDistance)
                {
                    mission.SetActive(false);
                }

                Vector3 directionToPlayer = player.position - transform.position;

                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, fixedUpDirection);

                transform.rotation = targetRotation;
        }
        
    }
}
