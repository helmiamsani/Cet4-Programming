using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LinearHealth
{
    [AddComponentMenu("Intro PRG/PRG/Player/Health - Linear")]
	public class LinearHealth : MonoBehaviour {
		[Header("Player Health")]

		public float maxHealth;
		public float curHealth;

		[Header("UI References")]

		public Slider healthBar;
		public Image sliderFill;

		void Update () 
		{
			healthBar.value = Mathf.Clamp01(curHealth / maxHealth); // Clamp01 is between 0 and 1.
			HealthManager();
		}
		
		void HealthManager()
		{
			if(curHealth <= 0 && sliderFill.enabled)
			{
				Debug.Log("Dead");
				sliderFill.enabled = false;
			}
			else if(!sliderFill.enabled && curHealth > 0)
			{
				Debug.Log("Revived");
				sliderFill.enabled = true;
			}
		}
	}
}
