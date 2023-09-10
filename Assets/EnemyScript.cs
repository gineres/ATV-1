using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Make sure to tag your player GameObject as "Player"
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            // Set the destination of the enemy to follow the player
            navMeshAgent.SetDestination(player.position);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BB")
            Destroy(gameObject);
        if (other.gameObject.tag == "Player"){
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
