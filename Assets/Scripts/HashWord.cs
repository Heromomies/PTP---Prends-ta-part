using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashWord : MonoBehaviour
{
	[SerializeField] private TextAsset words;
	[SerializeField] private bool useCase;
	public List<string> wordHashes = new List<string>();

	#region Singleton

	private static HashWord hashWord;

	public static HashWord Instance => hashWord;
	// Start is called before the first frame update

	private void Awake()
	{
		hashWord = this;
		
		// Creates the hashset data set at the start of the game.
		var words = this.words.text.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0, count = words.Length; i < count; i++)
		{
			//Debug.Log ( $"Read {words[i]} from the words list." );
			wordHashes.Add(useCase ? words[i] : words[i].ToLower());
		}
		//  Debug.Log ( $"Hashset contains One : {Contains ( "One" )}" );
	}

	#endregion

	public bool Contains(string word)
	{
		return wordHashes.Contains(useCase ? word : word.ToLower());
	}
}