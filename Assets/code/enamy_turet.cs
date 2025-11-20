using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class enamy_turet : MonoBehaviour
{

    public Transform player;

    public float activationRange;
    public float stoprange;
    private bool isActivated = false;

    private NavMeshAgent agent;

    private float timebetweenshots;
    public float starttimebetweenshots;

    public GameObject projectile;
    public Transform shootpoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError($"NavMeshAgent component missing on '{gameObject.name}'. Disabling '{nameof(enamy_turet)}'.");
            enabled = false;
            return;
        }

        agent.stoppingDistance = stoprange;
        
    }

   
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= activationRange)
        {
            isActivated = true;
        }
        if (isActivated == true)
        {
            if (agent == null)
            {
                return;
            }

            agent.SetDestination(player.position);

            if(Vector3.Distance(player.position, transform.position) <= agent.stoppingDistance)
            {
                agent.transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

                if (timebetweenshots <= 0)
                {
                    Instantiate(projectile, shootpoint.position, shootpoint.rotation);
                    timebetweenshots = starttimebetweenshots;
                }
                else
                {
                    timebetweenshots -= Time.deltaTime;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, activationRange);
        Gizmos.DrawWireSphere(transform.position, stoprange);
    }
}
