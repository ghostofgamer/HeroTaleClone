using PlayerContent;
using UnityEngine;

public class Awarding : MonoBehaviour
{
    [SerializeField] private PlayerLevel _playerLevel;

    private int _experience;

    public void Init(int experience)
    {
        _experience = experience;
        RewardPlayer();
    }

    private void RewardPlayer()
    {
        _playerLevel.AddExperience(_experience);
    }
}