using System;
using TMPro;
using UnityEngine;

public class FieldInput : MonoBehaviour
{
    private TMP_InputField _inputField;

    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onValueChanged.AddListener(SubmitName);

        WinToHighScoreButton.OnButtonPressed += ResetField;
        GameOverToHighScoreButton.OnButtonPressed += ResetField;
    }

    private void OnDisable()
    {
        WinToHighScoreButton.OnButtonPressed -= ResetField;
        GameOverToHighScoreButton.OnButtonPressed -= ResetField;
    }

    private void ResetField()
    {
        _inputField.text = "Enter Your Name";
    }

    private void SubmitName(string name)
    {
        S.I.GameManager.Name = name;
    }
}