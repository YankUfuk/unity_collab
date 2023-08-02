using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fps : MonoBehaviour
{
    public TMP_Text fpsText;

    [SerializeField]
    private float _refreshTime = 0.5f;
    private int _framecounter;
    private float _timecounter;
    private int _fps; // Change the data type to int


    // Update is called once per frame
    void Update()
    {
        if (_timecounter < _refreshTime)
        {
            _timecounter += Time.deltaTime;
            _framecounter++;
        }
        else
        {
            _fps = Mathf.RoundToInt(_framecounter / _timecounter); // Round to nearest integer
            _framecounter = 0;
            _timecounter = 0;
        }

        fpsText.text = "FPS: " + _fps.ToString();
    }
}
