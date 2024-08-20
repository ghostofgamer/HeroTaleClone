using System.Collections;
using UnityEngine;

public class PlayerAnmimation : MonoBehaviour
{
    [SerializeField] private GameObject _playerAttack;
    [SerializeField] private GameObject _playerIdle;

    private void Start()
    {
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        _playerIdle.SetActive(true);
        _playerAttack.SetActive(false);
        yield return new WaitForSeconds(3f);
        _playerIdle.SetActive(false);
        _playerAttack.SetActive(true);
        yield return new WaitForSeconds(3f);
        _playerIdle.SetActive(true);
        _playerAttack.SetActive(false);
        yield return new WaitForSeconds(3f);
        _playerIdle.SetActive(false);
        _playerAttack.SetActive(true);
        yield return new WaitForSeconds(3f);
        _playerIdle.SetActive(true);
        _playerAttack.SetActive(false);
        yield return new WaitForSeconds(3f);
        _playerIdle.SetActive(false);
        _playerAttack.SetActive(true);
    }
}
