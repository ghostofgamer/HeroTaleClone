using PlayerContent;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _healButton;
    [SerializeField] private GameObject _escapeButton;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Start()
    {
        DefaultStage();
    }

    public void BattleStage()
    {
        _startButton.SetActive(false);
        _healButton.SetActive(false);
        _escapeButton.SetActive(true);
    }

    public void DefaultStage()
    {
        _startButton.SetActive(true);
        _healButton.SetActive(true);
        _escapeButton.SetActive(false);
    }

    public void SearchStage()
    {
        _startButton.SetActive(false);
        _healButton.SetActive(false);
        _escapeButton.SetActive(false);
    }
}
