using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class MovTank : MonoBehaviour
{
    public float velocidad;
    public float distancia;
    private float contador;
    private float posInici;
	public GameObject balloonPref;
	public string WordsFileName = "Words.json";
	Word[] Words;
	public Transform spawnBallon;
	public int CurrentWords = 0;
	public int MaxWords = 4;
	public float WordDelay = 10.0f;
	public GameMaster gm;
	private float wordTime;
    private float posicionActual;
    private float posicionUltima;

    void Start()
    {
        posInici = transform.position.x;
		wordTime = Time.time + WordDelay;
		LoadGameData ();
    }

	void SelectWord(){
		if (CurrentWords < MaxWords && (wordTime < Time.time)) {
			wordTime = Time.time + WordDelay;
			balloonPref.transform.localScale = new Vector3 (3, 3, 3);
			Word randomWord = Words [Random.Range (0, Words.Length)];
			gm.AddBalloon (randomWord.Text, randomWord.Points);
			balloonPref.GetComponent<balloon> ().word = randomWord.Text;
			balloonPref.name = randomWord.Text;
			balloonPref.GetComponent<SpriteRenderer> ().color =  Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			Instantiate (balloonPref, spawnBallon.position , Quaternion.identity, transform);
			CurrentWords++;
		}
	}

	private void LoadGameData()
	{
		string filePath = Path.Combine(Application.streamingAssetsPath, WordsFileName);

		if(File.Exists(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath); 
			Debug.Log (dataAsJson);
			Words = JsonHelper.FromJson<Word>(dataAsJson);
		}
		else
		{
			Debug.LogError("Cannot load game data!");
		}


	}

    void Update()
    {
        contador += Time.deltaTime * velocidad;
        transform.position = new Vector2(Mathf.PingPong(contador, distancia) + posInici, transform.position.y);
        posicionActual = transform.position.x;
		/*
        if (posicionActual < posicionUltima)
        {
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
        if (posicionActual > posicionUltima)
        {
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
        }*/
		SelectWord ();
        posicionUltima = transform.position.x;
    }

}
