using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class ValueController : MonoBehaviour
{
    public float TargetWork;
    public float MaxSight;
    public float WorkValue;
    public float Sight;
    public float AsthenopiaValue = 0;   //control the speed of myopia degree
    public Slider WorkSlider;
    public Slider SightSlider;
    public Slider AsthenopiaSlider;
    public float workspeed;
    public float sightspeed;
    public Transform LookPosition;
    public Text endWord;
    public bool isWorking;
    public bool isLighting;
    public bool isLookingWindow;
    public Material Myopia;
    private bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        WorkSlider.value = 1;
        SightSlider.value = 1;
        AsthenopiaSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            if (isWorking)
            {
                if (isLighting)
                {
                    AsthenopiaValue += Time.deltaTime / 8f;
                }
                else
                {
                    AsthenopiaValue += Time.deltaTime / 3f;
                }
                AsthenopiaValue = Mathf.Min(1, AsthenopiaValue);
                Sight += Time.deltaTime * AsthenopiaValue * 20;
                Sight = Mathf.Min(MaxSight, Sight);
                WorkValue += Time.deltaTime * 5;
            }
            else if (isLookingWindow)
            {
                AsthenopiaValue -= Time.deltaTime / 3f;
                AsthenopiaValue = Mathf.Max(0, AsthenopiaValue);
            }
            else
            {
                AsthenopiaValue -= Time.deltaTime / 6f;
                AsthenopiaValue = Mathf.Max(0, AsthenopiaValue);
            }
        }
        Myopia.SetFloat("_Radius", Sight / 5);
        WorkSlider.value = (float)WorkValue / TargetWork;
        SightSlider.value = (float)Sight / MaxSight;
        AsthenopiaSlider.value = (float)AsthenopiaValue;
        if (WorkValue >= TargetWork && !isEnd)
        {
            isEnd = true;
            this.transform.position = LookPosition.position;
            transform.rotation = LookPosition.rotation;
            endWord.gameObject.SetActive(true);

        }
        if (Input.GetMouseButtonDown(0) && isEnd)
        {
            endWord.text = "Your myopia degree is " + ((int)Sight).ToString();
        }
    }
}
