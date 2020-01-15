using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassController : MonoBehaviour
{
    [Range(0,1)]
    public float position;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasRenderer>().GetMaterial(0).SetTextureOffset("_MainTex", new Vector2(0, -position));
        transform.position = new Vector3(transform.position.x, 540 - position * 1080, transform.position.z);
    }
}
