using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    public float speed = 5.0f;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            velocity *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        transform.Translate(velocity * Time.deltaTime);
        if (transform.position.x > 2.8f)
        {
            velocity = new Vector3(-speed, 0, 0);
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        else if (transform.position.x < -2.8f)
        {
            velocity = new Vector3(speed, 0, 0);
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }
}
