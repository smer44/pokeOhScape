using UnityEngine;

public class UnitMB : MonoBehaviour
{
    public UnitSO initialData;
    public UnitSO data;

    public string team;

    void Start()
    {
        ResetData();
    }

    void ResetData()
    {   
        //data represents current units state like current hp, so they are copied from initial data.
        data = initialData.Copy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
