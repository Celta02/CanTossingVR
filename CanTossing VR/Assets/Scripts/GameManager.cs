using System;
using UnityEngine;

    public class GameManager: MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] CansManager _cansManager;
        [SerializeField] BallsManager _ballsManager;
        
        [Header("Attempts Attribute and UI")]
        [SerializeField] UIAttempts _uiAttempts;
        [SerializeField] UITotalAttempts _uiTotalAttempts;
        [SerializeField] int _maxAttempts;
        int _attemptsLeft;
        
        void Awake() => _ballsManager.Manager = this;

        void Start()
        {
            _attemptsLeft = _maxAttempts;
            _uiAttempts.WriteUI(_attemptsLeft);
            _uiTotalAttempts.WriteUI(_maxAttempts);
        }

        public void UseAttempt()
        {
            _attemptsLeft--;
            _uiAttempts.WriteUI(_attemptsLeft);
            
            if (_attemptsLeft > 0) return;
            RestartAttempts();
        }

        void RestartAttempts()
        {
            _cansManager.RestartCans();
            _attemptsLeft = _maxAttempts;
            _uiAttempts.WriteUI(_attemptsLeft);
        }
    }