using UnityEngine;

public class SpriteFromSOMB : MonoBehaviour
{
    public SpriteSO spriteSO;
    public GameObject unitSprite;
    public Vector2 targetSize = new Vector2(1f, 1f);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetSprite(unitSprite, spriteSO.sprite);

        Debug.Log($"Sprite set: {spriteSO.sprite}");
    }


    void SetSprite(GameObject go, Sprite sprite)
    {   
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        sr.sprite = spriteSO.sprite;
        //resize sprite to given transform size:
        Vector2 spriteSize = sprite.bounds.size;
        Vector3 newScale = go.transform.localScale;

        newScale.x = targetSize.x / spriteSize.x;
        newScale.y = targetSize.y / spriteSize.y;
        go.transform.localScale = newScale;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
