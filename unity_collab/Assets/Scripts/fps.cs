using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fps : MonoBehaviour
{
    public TMP_Text fpsText;

    [SerializeField]
    private float _refreshTime =0.5f;
    private int _framecounter;
    private float _timecounter;
    private float _fps;


    // Update is called once per frame
    void Update()
    {
        if(_timecounter<_refreshTime){

            _timecounter+=Time.deltaTime;
            _framecounter++;
        }
        else
        {
            {
                _fps = _framecounter/ _timecounter;
                _framecounter =0;
                _timecounter = 0;
            }
        }
        fpsText.text= "FPS: " + _fps.ToString();
    }
}
