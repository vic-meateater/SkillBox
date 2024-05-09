using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _winningText;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameController _gameController;
    void Start()
    {
        _restartGameButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        _gameController.StartNewGame();
        _timer.StartTimer();
    }

    public void ShowEndGameScreen(bool isWinning)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        if (isWinning)
        {
            _winningText.text = "Вы выиграли";
        }
        else
        {
            _winningText.text = "Вы проиграли";
            _gameController.ResetWinCounter();
        }
    }
}