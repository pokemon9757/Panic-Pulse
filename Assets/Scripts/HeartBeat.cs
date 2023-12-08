using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    XRIDefaultInputActions _inputActions;
    public int CurrentHR = 60;
    public int CurrentHRLevel = 1;
    public const int NORMAL_HR = 60;
    public const int MID_HR = 80;
    public const int HIGH_HR = 110;
    public float fluctuationDelay = 3;
    float _timer;

    void OnEnable()
    {
        _inputActions = new XRIDefaultInputActions();
        _inputActions.Enable();
        _inputActions.GameActions.IncreaseHR.performed += IncreaseHR;
        _inputActions.GameActions.DecreaseHR.performed += DecreaseHR;
    }

    void OnDisable()
    {
        _inputActions.Disable();
    }

    void IncreaseHR(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Increase HR");
        if (CurrentHRLevel < 3) CurrentHRLevel++;
    }

    void DecreaseHR(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Decrease HR");
        if (CurrentHRLevel > 1) CurrentHRLevel--;
    }

    void Update()
    {
        FluctuateHR();
        displayText.text = "" + CurrentHR;
    }

    void FluctuateHR()
    {
        if (_timer <= 0)
        {
            _timer = fluctuationDelay;
            switch (CurrentHRLevel)
            {
                case 1:
                    CurrentHR = Random.Range(NORMAL_HR, (NORMAL_HR + MID_HR) / 2);
                    break;
                case 2:
                    CurrentHR = Random.Range((NORMAL_HR + MID_HR) / 2, (MID_HR + HIGH_HR) / 2);
                    break;
                case 3:
                    CurrentHR = Random.Range((MID_HR + HIGH_HR) / 2, 150);
                    break;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    public int GetHRLevel()
    {
        if (CurrentHR < (NORMAL_HR + MID_HR) / 2)
            return 1;
        if (CurrentHR < (MID_HR + HIGH_HR) / 2)
            return 2;
        return 3;
    }
}
