using UnityEngine;

public class UnitMB : MonoBehaviour
{
    public UnitSO initialData;
    public UnitSO data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetData();
    }

    void ResetData()
    {
        data = initialData.Copy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
