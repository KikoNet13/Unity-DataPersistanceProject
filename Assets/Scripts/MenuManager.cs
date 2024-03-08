using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_Text highScoreText;
    public TMP_InputField nameInputField;
    public Button startButton;

    void Start()
    {
        // Deshabilitar el botón de inicio al iniciar la escena
        startButton.interactable = false;

        // Suscribirse al evento de cambio de texto en el campo de entrada del nombre
        nameInputField.onValueChanged.AddListener(OnNameInputValueChanged);

        // Establecer el nombre del jugador en el campo de entrada del nombre
        nameInputField.text = GameManager.Instance.data.playerName;

        // Establecer el texto del puntaje más alto
        highScoreText.text = "High Score: " + GameManager.Instance.data.highScorePlayerName + " - " + GameManager.Instance.data.highScore;
    }

    void OnNameInputValueChanged(string newText)
    {
        // Habilitar el botón de inicio si hay texto en el campo de entrada del nombre
        startButton.interactable = !string.IsNullOrEmpty(newText);
    }

    public void StartButtonClicked()
    {
        // Establecer el nombre del jugador en el GameManager
        GameManager.Instance.SetPlayerName(nameInputField.text);

        // Cargar la escena del juego
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
