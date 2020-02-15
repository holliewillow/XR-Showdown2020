using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public List<Sprite> sprites;
    private int n;

    private void OnEnable()
    {
        n = Random.Range(0, sprites.Count);
        GetComponent<SpriteRenderer>().sprite = sprites[n];
    }
}
