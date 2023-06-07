using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float minSpeed = 12.0f;
    public float maxSpeed = 13.0f;
    public float xPosRange = 4;
    public float yPos = -6;
    private Spawn gameManager;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Spawn>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos(); 
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        if (gameObject.name.Contains("Skull")){
            gameManager.UpdateScore(-10, 1);
        }
        else
        {
            gameManager.UpdateScore(5, 0);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sensor")
        {
            Destroy(gameObject);
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xPosRange, xPosRange), 2);
    }
}
