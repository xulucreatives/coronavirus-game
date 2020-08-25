using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
	public float timeStart;
	public Text textBox;
	public playermove pm;
	private GameObject player;
	public int countdownNumDied = 0;







	// Use this for initialization
	void Start()
	{

		pm= FindObjectOfType<playermove>();
		player = GameObject.FindWithTag("Citizen");







	}

	// Update is called once per frame
	void Update()
	{
		textBox.text = timeStart.ToString();
		if (timeStart < 0)
		{
			Destroy(player);
			countdownNumDied += 1;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
		}

		if (pm.positive)
		{
			timeStart -= Time.deltaTime;
		
			

		}
		


	}
}