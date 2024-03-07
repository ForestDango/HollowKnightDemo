using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Animator[] healthItems;
    public Animator geo;
    public float showHealthItemIntervalTime = 0.2f;

    private PlayerData characterData;

    private void Start()
    {
        characterData = FindObjectOfType<PlayerData>();
    }

    public void Hurt()
    {
        if (characterData.GetDeadStatement())
            return;
        characterData.LoseHealth(1);
        int health = characterData.GetCurrentHealth();
        Debug.Log("Current Health :" + health);
        healthItems[health].SetTrigger("Hurt");
    }

    public IEnumerator ShowHealthItems()
    {
        for (int i = 0; i < healthItems.Length; i++)
        {
            healthItems[i].SetTrigger("Respawn");
            yield return new WaitForSeconds(showHealthItemIntervalTime);
        }
        yield return new WaitForSeconds(showHealthItemIntervalTime);
        geo.Play("Enter");
    }

    public void HideHealthItems()
    {
        geo.Play("Quit");
        for (int i = 0; i < healthItems.Length; i++)
        {
            healthItems[i].SetTrigger("Hide");
        }
    }
}
