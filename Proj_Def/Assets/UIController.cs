using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public StateController stateController;
    public GameObject startMenu;

    void Start()
    {
        stateController.OnStateChanged += UpdateUI;
    }

    void UpdateUI(StateController.GameState state)
    {
        startMenu.SetActive(state==StateController.GameState.START);
    }
}
