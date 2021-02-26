using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    public float delay = 0f;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var sprite = gameObject.GetComponent<SpriteRenderer>();
        if (sprite)
        {
            var color = sprite.color;
            color.a = 1 - timer / delay;
            sprite.color = color;
        }
    }
}
