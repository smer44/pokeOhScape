using UnityEngine;

[CreateAssetMenu(fileName = "ObjectWithHitPointsSO", menuName = "Scriptable Objects/ObjectWithHitPointsSO")]
public class ObjectWithHitPointsSO : ScriptableObject
{
    [Header("Basic info")]
    public string Name;

    [Header("Stats Info")]
    public int hp;

    public ObjectWithHitPointsSO Copy()
    {
        ObjectWithHitPointsSO obj = ScriptableObject.CreateInstance<ObjectWithHitPointsSO>();
        obj.Name = Name + "_copy";
        obj.hp = this.hp;
        return obj;

    }


}
