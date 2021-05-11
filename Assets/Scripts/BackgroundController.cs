using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    public float speed;
    public float maxY;
    public float minY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(transform.position.y >= maxY)
        {
            Vector2 startPos = new Vector2(transform.position.x, minY);
            transform.position = startPos;
        }
    }
}
