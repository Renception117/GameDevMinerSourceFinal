using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreController : MonoBehaviour
{
    public float speed;
    public float value;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(transform.position.y > 5.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
