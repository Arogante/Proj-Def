using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private RectTransform rect;
    private Image image;
    private int levelSpeed = 400;
    public StateController stateController;

    public Vector3 AnchoredPosition { get { return rect.anchoredPosition3D; } set { rect.anchoredPosition3D = value; } }
    public Vector2 Size { get { return rect.sizeDelta; } set { rect.sizeDelta = value; } }

    public Color BackgroundColor { get { return image.color; } set { image.color = value; } }

    private void Awake() {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    void Update() {

        if (stateController.State == StateController.GameState.PLAY) {
            AnchoredPosition += Vector3.down*Time.deltaTime*levelSpeed;
        }
    }
    public void SetStateController(StateController stateController) {
        this.stateController = stateController;
    }
    

}
