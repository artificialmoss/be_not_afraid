using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : SingletonBase<LevelState>
{
    [SerializeField] private Player player;
    [SerializeField] private List<Monster> monsters;
    [SerializeField] private int currentMonsterIndex = 0;

    public void HandleAttack(HitResult.Result result)
    {
        switch (result)
        {
            case HitResult.Result.Early:
            {
                goto case HitResult.Result.Miss;
            }
            case HitResult.Result.Late:
            {
                goto case HitResult.Result.Miss;
            }
            case HitResult.Result.Miss:
            {
                var damage = monsters[currentMonsterIndex].GiveDamage();
                player.TakeDamage(damage);
                break;
            }
            case HitResult.Result.Why:
            {
                var damage = monsters[currentMonsterIndex].GiveDamage();
                player.TakeDamage(damage);
                break;
            }
            case HitResult.Result.Okay:
            {
                var damage = player.GiveDamage(result);
                monsters[currentMonsterIndex].TakeDamage(damage);
                break;
            }
            case HitResult.Result.Good:
            {
                var damage = player.GiveDamage(result);
                monsters[currentMonsterIndex].TakeDamage(damage);
                break;
            }
            case HitResult.Result.Perfect:
            {
                var damage = player.GiveDamage(result);
                monsters[currentMonsterIndex].TakeDamage(damage);
                break;
            }
        }
        // Debug.Log("Player: " + player.GetHealth());
        // Debug.Log("Monster: " + monsters[currentMonsterIndex].GetHealth());
        // Debug.Log(result);
        if (player.GetHealth() == 0)
        {
            SceneManager.LoadSceneAsync("LoseEndScreen");
        }

        if (monsters[currentMonsterIndex].GetHealth() == 0)
        {
            SceneManager.LoadSceneAsync("WinEndscreen");
        }
    }
}