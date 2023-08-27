using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootExperience : MonoBehaviour
{
    public int MinimumExpToGive = 100;

    private void Update()
    {
        Destroy(gameObject, 120f);
    }
    public float CountExperienceToGive(GameObject player)
    {
        float _givenExp = (player.GetComponent<PlayerProgress>().CurrentLVL+1) * MinimumExpToGive;
        return _givenExp;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerProgress>())
        {
            PlayerProgress _progress = collision.GetComponent<PlayerProgress>();
            _progress.CurrentExperience += CountExperienceToGive(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
