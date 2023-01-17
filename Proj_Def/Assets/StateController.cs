using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum GameState {START,PLAY,LOSE,GAME_OVER};
    public event System.Action<GameState> OnStateChanged;
    private GameState gameState;
    private List<LevelController> levels = new List<LevelController>();

    [SerializeField] private LevelController levelPrefab = null;
    [SerializeField] private Transform levelRegion = null;
    [SerializeField] private List<Color> colors = new List<Color>();

    public GameState State { get => gameState; set { gameState = value; OnStateChanged?.Invoke(gameState); } }

    private void Start() {
        int levelCount = 3;
        for (int i = 0; i < levelCount; i++) {
            levels.Add(SpawnNewLevel());
        }
        ResetLevels();
    }

    public void StartGame() {
        State = GameState.PLAY;
    }

    private LevelController SpawnNewLevel() {
        LevelController level=Instantiate(levelPrefab, Vector3.zero, Quaternion.identity, levelRegion);
        level.AnchoredPosition = Vector3.zero;
        level.BackgroundColor = colors[Random.Range(0, colors.Count)];
        level.Size = new Vector2(levelRegion.parent.GetComponent<RectTransform>().sizeDelta.x,
            levelRegion.parent.GetComponent<RectTransform>().sizeDelta.y * 2);
        level.SetStateController(this);
        return level;
    }
    private void ResetLevels()
    {
        levels[0].AnchoredPosition = Vector3.zero;
        for (int i = 1; i < levels.Count; i++) {
            LevelController prevLevel = levels[i - 1];
            levels[i].AnchoredPosition = new Vector3(0, prevLevel.AnchoredPosition.y + prevLevel.Size.y);
        }
    }
}
