using UnityEngine;

public class ICEdrop : MonoBehaviour
{

    public GameObject[] enamys; 
    public float spawnInterval = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("icespawn", spawnInterval, spawnInterval);
    }

    private void icespawn()    
    {

        int randomindex = Random.Range(0, enamys.Length);
        Vector3 randomspawnposition = new Vector3(Random.Range(-2.5f, 2.5f), 8f, Random.Range(18f, 45f));

        Instantiate(enamys[randomindex], randomspawnposition, Quaternion.identity);

    }
    

}
