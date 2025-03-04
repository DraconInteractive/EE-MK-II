﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DuloGames.UI;

public class ActionBarCanvas : MonoBehaviour {
	StatisticsProfile playerStats;
	public static ActionBarCanvas actionBar;

	public UIProgressBar hpBar, mpBar, xpBar;
	void Awake () {
		actionBar = this;
	}
	// Use this for initialization
	void Start () {
		playerStats = Player.player.playerStats;
		StartCoroutine (UpdateRepeater ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateActionBar()
	{
		CharacterStatistics stats = playerStats.stats;
		hpBar.fillAmount = stats.health.current / stats.health.maximum;
		mpBar.fillAmount = stats.mana.current / stats.mana.maximum;
//		float hpt = (int)(hpBar.fillAmount * 100);
//		float mpt = (int)(mpBar.fillAmount * 100);
//		hpText.text = hpt.ToString() + "%";
//		mpText.text = mpt.ToString() + "%";
		//levelText.text = stats.level.current.ToString();
		xpBar.fillAmount = stats.experience.current / stats.mana.maximum;
	}

	IEnumerator UpdateRepeater () {
		while (true) {
			UpdateActionBar ();
			yield return new WaitForSeconds (0.2f);
		}
		//yield break;
	}
}
