using UnityEngine;

[CreateAssetMenu(fileName = "ObjectWithHitPointsSO", menuName = "Scriptable Objects/ObjectWithHitPointsSO")]
public class ObjectWithHitPointsSO : ScriptableObject
{
    public string unitName;

    public int hitPoints;

    public ObjectWithHitPointsSO Copy()
    {
        ObjectWithHitPointsSO obj = ScriptableObject.CreateInstance<ObjectWithHitPointsSO>();
        obj.unitName = unitName + "_copy";
        obj.hitPoints = this.hitPoints;
        return obj;

    }


}
