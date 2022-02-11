using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ReplaceWord : MonoBehaviour
{
    public Slider timeSlider;
    public float timeToSpeak;
    private float _time;
    public GameObject textDisplayWord;
    public TextMeshProUGUI textDisplayPlayerName;
    
    private bool _isTiming;
    
    // Start is called before the first frame update
    void Start()
    {
        var localManager = textDisplayWord.GetComponent<LocalizationParamsManager>();
        var randomWord = Random.Range(0, HashWord.Instance.wordHashes.Count);
        
        localManager.SetParameterValue("WORD", HashWord.Instance.wordHashes[randomWord]);

        var randomPlayer = Random.Range(0, GameManager.Instance.playerNames.Count);

        textDisplayPlayerName.text = GameManager.Instance.playerNames[randomPlayer];
        _isTiming = true;
    }

    private void Update()
    {
        if (_isTiming)
        {
            _time += Time.deltaTime;
            timeSlider.value = _time;
        }
        
        if (_time >= timeToSpeak)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        _isTiming = false;
        //TODO end of the game
    }
}
