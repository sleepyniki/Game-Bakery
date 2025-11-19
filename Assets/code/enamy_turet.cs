using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enamy_turet : MonoBehaviour
{

    public Transform player;

    public float activationRange;
    public float stoprange;
    private bool isActivated = false;

    private NavMeshAgent agent;

    private float timebetweenshots;
    private float starttimebetweenshots;

    public GameObject projectile;
    public Transform shootpoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
            agent.SetDestination(player.position);

            if(vector3.Distance(player.position, transform.position) <= agent.stoprange)
            {
                agent.transform.lookat(new vector3(player.position.x, agent.transform.position.y, player.position.z));

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
