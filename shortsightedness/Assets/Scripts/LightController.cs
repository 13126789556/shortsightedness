using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public bool open;
    public GameObject lamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            lamp.SetActive(true);
        }
        else if(!open)
        {
            lamp.SetActive(false);
        }
    }
}
