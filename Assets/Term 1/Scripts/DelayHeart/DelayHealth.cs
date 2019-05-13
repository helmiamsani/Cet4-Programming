using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Get the UI

namespace LinearDelayHealth
{
    [AddComponentMenu("Intro PRG/PRG/Player/Health - LinearDelay")]
    public class DelayHealth : MonoBehaviour 
    {
        [Header("Pl")]
        // Player health max and current and delay
        public float maxHealth;
        public float curHealth;
        public float delayHealth;

        // Speed
        public float speed;


        [Header("UI References")]

        // Reference to Slider
        public Slider healthSlider;
        // Reference to Fill
        public Image healthFill;
        // Reference to Delay Slider
        public Slider delaySlider;
        // Reference to Delay Fill
        public Image delayFill;
 

	    void Update () 
	    {
            // setting of current health value on slider
            healthSlider.value = Mathf.Clamp01(curHealth / maxHealth);

		    // if delay health is bigger than our current health
            if(delayHealth > curHealth)
            {
                // - over time according to our speed make delay health match the current health
                delayHealth -= Time.deltaTime * speed;
            }

            // setting of delay health value on slider
            delaySlider.value = Mathf.Clamp01(delayHealth / maxHealth);

            HealthManager();
        }

	    void HealthManager()
        {
            // if Control the display of the current health fill
            if(curHealth <= 0 && healthFill.enabled)
            {
                healthFill.enabled = false;
            }
            else if (!healthFill.enabled && curHealth > 0)
            {
                Debug.Log("Revive");
                healthFill.enabled = enabled;
            }
            if(delayHealth <= 0 && delayFill.enabled)
            {
                Debug.Log("Dead");
                delayFill.enabled = false;
            }
            else if (delayHealth < curHealth)
            {
                healthFill.enabled = enabled;
                delayHealth = curHealth;
                delaySlider.value = healthSlider.value;
            }
        }
    }
}

