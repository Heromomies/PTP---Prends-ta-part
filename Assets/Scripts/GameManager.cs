using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public TMP_InputField inputFieldToGetName;
	public RectTransform textContainer;
	public GameObject textToSpawn;
	
	public List<string> playerNames;

	public GameObject panelMenu, panelGameOne;
	
	#region Singleton

	private static GameManager _gameManager;

	public static GameManager Instance => _gameManager;
	// Start is called before the first frame update

	private void Awake()
	{
		_gameManager = this;
		
	}

	#endregion
	
	
	
	public void OnClickToAddPlayer()
    {
	    playerNames.Add(inputFieldToGetName.text);

	    GameObject textSpawned = Instantiate(textToSpawn, textContainer);
	    textSpawned.GetComponent<TextMeshProUGUI>().text = inputFieldToGetName.text;
	    var sizeDelta = textContainer.sizeDelta;
	    textContainer.sizeDelta = new Vector2(sizeDelta.x, sizeDelta.y + 15);
	    var localPosition = textContainer.localPosition;
	    textContainer.localPosition = new Vector3(localPosition.x, localPosition.y -25, localPosition.z);
	   
	    inputFieldToGetName.text = "";
    }

	public void LaunchGame()
	{
		panelMenu.SetActive(false);
		panelGameOne.SetActive(true);
	}
   
}
