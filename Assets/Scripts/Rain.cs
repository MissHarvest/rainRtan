using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 0;
    enum EType { Small, Normal, Large, Danger, Max };
    EType type = EType.Small;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        type = (EType)Random.Range(0, (int)EType.Max);
        transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 4.3f, 0);

        switch (type)
        {
            case EType.Small:
                size = 0.5f;
                score = 1;
                spriteRenderer.color = Color.blue;
                break;
            case EType.Normal:
                size = 0.7f;
                score = 2;
                spriteRenderer.color = Color.yellow;
                break;
            case EType.Large:
                size = 1.0f;
                score = 3;
                spriteRenderer.color = Color.green;
                break;
            case EType.Danger:
                size = 0.8f;
                score = -5;
                spriteRenderer.color = Color.red;
                break;
        }
        transform.localScale = new Vector3(size, size, 0);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            Destroy(gameObject);
        }
    }
}
