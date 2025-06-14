using UnityEngine;

public class SpriteFromSOMB : MonoBehaviour
{
    public SpriteSO spriteSO;
    public Vector2 targetSize = new Vector2(1f, 1f);
    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetSprite(spriteSO.sprite);

        Debug.Log($"Sprite set: {spriteSO.sprite}");
    }


    void SetSprite(Sprite sprite)
    {
        sr.sprite = spriteSO.sprite;
        //resize sprite to given transform size:
        Vector2 spriteSize = sprite.bounds.size;
        Vector3 newScale = transform.localScale;

        newScale.x = targetSize.x / spriteSize.x;
        newScale.y = targetSize.y / spriteSize.y;
        transform.localScale = newScale;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
