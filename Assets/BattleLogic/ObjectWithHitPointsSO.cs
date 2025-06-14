using UnityEngine;

[CreateAssetMenu(fileName = "ObjectWithHitPointsSO", menuName = "Scriptable Objects/ObjectWithHitPointsSO")]
public class ObjectWithHitPointsSO : SpriteSO
{
    public string unitName;

    public int hitPoints;


    public void TakeDamage(int damageAmount)
    {
        hitPoints = Mathf.Max(hitPoints-damageAmount, 0);

     }

}
