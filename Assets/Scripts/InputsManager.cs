using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputsManager : MonoBehaviour
{
    public GameController controller;
    public InputField inputField;

    public void spawnTimeToController()
    {
        controller.SetSpawnPeriodString(inputField.text);
    }

    public void speedToController()
    {
        controller.SetSpeedToCubesString(inputField.text);
    }

    public void distanceToController()
    {
        controller.SetCubeDistanceDestroyString(inputField.text);
    }
}
