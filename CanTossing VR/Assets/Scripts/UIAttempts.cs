using TMPro;
using UnityEngine;

    public class UIAttempts: MonoBehaviour
    {
        TMP_Text _attemptsTMP;
        void Awake() => _attemptsTMP = GetComponent<TMP_Text>();

        public void WriteUI(int attemptsLeft)
        {
            var text = attemptsLeft.ToString();
            _attemptsTMP.text = text;
        }
    }