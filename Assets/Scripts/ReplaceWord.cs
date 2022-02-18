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

    public GameObject panelEnd;
    private bool _isTiming;

    private void Start()
    {
        ChangeWordAndPlayerName();
    }

    // Start is called before the first frame update
    void ChangeWordAndPlayerName()
    {
        var localManager = textDisplayWord.GetComponent<LocalizationParamsManager>();
        var randomWord = Random.Range(0, HashWord.Instance.wordHashes.Count);
        
        localManager.SetParameterValue("WORD", HashWord.Instance.wordHashes[randomWord]);
        HashWord.Instance.wordHashes.Remove(HashWord.Instance.wordHashes[randomWord]);

        var randomPlayer = Random.Range(0, GameManager.Instance.playerNames.Count);
        
        var localManagerName = textDisplayPlayerName.GetComponent<LocalizationParamsManager>();
        localManagerName.SetParameterValue("NAME", GameManager.Instance.playerNames[randomPlayer]);
        GameManager.Instance.playerNames.Remove(GameManager.Instance.playerNames[randomPlayer]);
        
        //textDisplayPlayerName.text = GameManager.Instance.playerNames[randomPlayer];
       
        
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
            panelEnd.SetActive(true);
        }

        if (GameManager.Instance.playerNames.Count == 0 || HashWord.Instance.wordHashes.Count == 0)
        {
            Debug.Log("Le jeu est fini");
        }
    }

    public void EndGame()
    {
        _isTiming = false;
        _time = 0;
        
        ChangeWordAndPlayerName();
        panelEnd.SetActive(false);
    }
}
