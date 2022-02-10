using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public TextMeshProUGUI textDisplayLetter;
	public TMP_InputField inputFieldToGetName;
	public RectTransform textContainer;
	public GameObject textToSpawn;
	
	private string[] _alphabet = new string[26] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};

	public List<string> _playerNames;
	
	// Start is called before the first frame update
    void Start()
    {
	  /*  int letterChoose = Random.Range(0, _alphabet.Length);
	    textDisplayLetter.text = _alphabet[letterChoose];*/
    }

    public void OnClickToAddPlayer()
    {
	    _playerNames.Add(inputFieldToGetName.text);

	    GameObject textSpawned = Instantiate(textToSpawn, textContainer);
	    textSpawned.GetComponent<TextMeshProUGUI>().text = inputFieldToGetName.text;
	    var sizeDelta = textContainer.sizeDelta;
	    textContainer.sizeDelta = new Vector2(sizeDelta.x, sizeDelta.y + 15);
	    var localPosition = textContainer.localPosition;
	    textContainer.localPosition = new Vector3(localPosition.x, localPosition.y -25, localPosition.z);
	   
	    inputFieldToGetName.text = "";
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
