using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : SingletonBase<LevelState>
{
    [SerializeField] private Player player;
    [SerializeField] private List<Monster> monsters;
    [SerializeField] private int currentMonsterIndex = 0;
    
    [SerializeField] private AudioSource humanDeathScream;
    [SerializeField] private AudioSource monsterDeathScream;
    
    [SerializeField] private GameObject winPrefab;
    
    public void HandleAttack(HitResult.Result result)
    {
        var attack = AttackMatcher.Instance.GetAttack(result);
        if (AttackMatcher.Instance.IsPlayerAttack(attack))
        {
            var damage = player.GiveDamage(attack);
            monsters[currentMonsterIndex].TakeDamage(damage);
        }
        else
        {
            var damage = monsters[currentMonsterIndex].GiveDamage(attack);
            player.TakeDamage(damage);
        }
        // Debug.Log("Player: " + player.GetHealth());
        // Debug.Log("Monster: " + monsters[currentMonsterIndex].GetHealth());
        // Debug.Log(result);
        if (player.GetHealth() == 0)
        {
            humanDeathScream.Play();
            SceneManager.LoadSceneAsync("LoseEndScreen");
        }

        if (monsters[currentMonsterIndex].GetHealth() == 0)
        {
            monsterDeathScream.Play();
            // SceneManager.LoadSceneAsync("WinEndscreen");
            Instantiate(winPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}