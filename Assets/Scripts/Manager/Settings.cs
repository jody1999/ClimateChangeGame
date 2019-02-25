using SA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gameManager;

    private static ResourcesManager _resourceManager;

    public static ResourcesManager GetResourcesManager()
    {
        if(_resourceManager == null )
        {
            _resourceManager = Resources.Load("ResourceManager") as ResourcesManager;
            _resourceManager.Init();
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetParentForCard(Transform c, Transform p)
    {
        c.SetParent(p);
        c.localPosition = Vector3.zero;
        c.localEulerAngles = Vector3.zero;
        c.localScale = Vector3.one;
    }
}