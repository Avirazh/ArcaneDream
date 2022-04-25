using UnityEngine;

namespace AI
{
    public class HpSystem : MonoBehaviour
    {
        [SerializeField] private int _maxHp;
        private int _currentHp;

        public int MaxHp => _maxHp;
        public int CurrentHp => _currentHp;

        private void Start()
        {
            _currentHp = _maxHp;
        }
        public void IncreaseHp(int addedHp)
        {
            _currentHp += addedHp;
            if (_currentHp > _maxHp)
            {
                _currentHp = _maxHp;
            }
        }
        public void DecreaseHp(int decreasedHp)
        {
            _currentHp -= decreasedHp;
            if (_currentHp < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}