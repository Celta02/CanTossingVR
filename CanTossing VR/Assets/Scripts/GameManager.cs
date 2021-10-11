using UnityEngine;

    public class GameManager: MonoBehaviour
    {
        [SerializeField] CansManager _cansManager;
        [SerializeField] BallsManager _ballsManager;
        
        [SerializeField] int _maxAttempts;
        int _attemptsUsed;
        
        void Awake() => _ballsManager.Manager = this;
        public void UseAttempt()
        {
            _attemptsUsed++;

            if (_attemptsUsed < _maxAttempts) return;
            
            _cansManager.RestartCans();
            _attemptsUsed = 0;
        }
        
        
    }