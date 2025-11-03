using UnityEngine;

public class respawn : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] float spawnValue;

    void Update()
    {
        if (player.position.y < spawnValue)
        {
            respawnpoint();
        }
    }

    private void respawnpoint()
    {
        player.position = spawnPoint.position;
    }
}
