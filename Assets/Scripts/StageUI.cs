using UnityEngine;

public class StageUI : MonoBehaviour
{
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _healButton;
    [SerializeField] private GameObject _escapeButton;
    [SerializeField] private GameObject _weaponChangerButton;

    private void Start()
    {
        DefaultStage();
    }

    public void BattleStage()
    {
        ChangeValue(false, false, true, true);
    }

    public void DefaultStage()
    {
        ChangeValue(true, true, false, false);
    }

    public void SearchStage()
    {
        ChangeValue(false, false, false, false);
    }

    private void ChangeValue(bool startActive, bool healActive, bool escapeActive, bool weaponChangerActive)
    {
        _startButton.SetActive(startActive);
        _healButton.SetActive(healActive);
        _escapeButton.SetActive(escapeActive);
        _weaponChangerButton.SetActive(weaponChangerActive);
    }
}