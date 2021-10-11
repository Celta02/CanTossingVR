using TMPro;
using UnityEngine;

    public class UITotalAttempts: MonoBehaviour
    {
        TMP_Text _totalAttemptsTMP;
        void Awake() => _totalAttemptsTMP = GetComponent<TMP_Text>();
        public void WriteUI(int totalAttempts)
        {
            var text = $"/ {totalAttempts}";
            _totalAttemptsTMP.text = text;
        }
    }