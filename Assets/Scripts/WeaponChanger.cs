using PlayerContent;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject _playerScytheAttack;
    [SerializeField] private GameObject _playerSwordIdle;
    [SerializeField] private GameObject _playerBowAttack;
    [SerializeField] private GameObject _playerBowIdle;
    [SerializeField] private PlayerAttack _playerAttack;

    public void ChangeWeapon()
    {
        if (_playerAttack.IsScytheWeapon)
        {
            _playerAttack.InitWeapon(_playerBowAttack,_playerBowIdle);
            
            if (_playerAttack.IsAttack)
            {
                _playerBowIdle.SetActive(true);
                _playerBowAttack.SetActive(false);
            }
            else if (_playerAttack.IsReload)
            {
                _playerBowIdle.SetActive(false);
                _playerBowAttack.SetActive(true);
            }
            
            _playerScytheAttack.SetActive(false);
            _playerSwordIdle.SetActive(false);
        }
            
        else
        {
             _playerAttack.InitWeapon(_playerScytheAttack,_playerSwordIdle);
             
             if (_playerAttack.IsAttack)
             {
                 _playerSwordIdle.SetActive(true);
                 _playerScytheAttack.SetActive(false);
             }
             else if (_playerAttack.IsReload)
             {
                 _playerSwordIdle.SetActive(false);
                 _playerScytheAttack.SetActive(true);
             }
             
             _playerBowIdle.SetActive(false);
             _playerBowAttack.SetActive(false);
        }
    }
}
