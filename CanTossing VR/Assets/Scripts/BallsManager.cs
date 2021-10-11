using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BallsManager: MonoBehaviour
    {
        [SerializeField] List<Transform> _spawningPositions;
        [SerializeField] GameObject _ballPrefab;
        GameManager _gameManager;

        public GameManager Manager { set => _gameManager = value; }


        void Awake()
        {
            for (var i = 0; i < _spawningPositions.Count; i++)
            {
                var spawnTransform = _spawningPositions[i];
                var ball = Instantiate(_ballPrefab, spawnTransform.position,Quaternion.identity, transform);
                var behaviour = ball.GetComponent<BallBehaviour>();
                behaviour.BallsManager = this;
                behaviour.BallNumber = i;
            }
        }

        public void RespawnBall(GameObject ball, int ballNumber) => StartCoroutine(RespawnCoroutine(ball, ballNumber, false));
        public void ReturnBallSafely(GameObject ball, int ballNumber) => StartCoroutine(RespawnCoroutine(ball, ballNumber, true));

        IEnumerator RespawnCoroutine(GameObject ball, int ballNumber, bool safely)
        {
            if(!safely)
                _gameManager.UseAttempt();
            
            //TODO Disappear Effect
            ball.SetActive(false);
            yield return new WaitForSeconds(3f);
            
            ball.transform.position = _spawningPositions[ballNumber].position;
            ball.SetActive(true);
            //TODO Reappear Effect
        }

    }