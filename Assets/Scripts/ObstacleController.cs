using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        GameObject dev = GameObject.Find("DevToolControl");
        if (dev.GetComponent<DeveloperToolController>().isNoClip)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > 5.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
