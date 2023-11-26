using UnityEngine;
using UnityEngine.UI;

public class ToggleSoundButton : MonoBehaviour
{
    private bool isMuted = false;
    private float savedVolume = 1.0f; // O volume original (100%) que será salvo e restaurado.

    public Sprite soundOnSprite; // Sprite quando o som está ligado.
    public Sprite soundOffSprite; // Sprite quando o som está desligado.
    public Image buttonImage; // Referência à imagem do botão.

    private void Start()
    {
        // Configure a imagem do botão com base no estado inicial.
        UpdateButtonImage();
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            // Salve o volume atual e defina o volume para 0 (mute).
            savedVolume = AudioListener.volume;
            AudioListener.volume = 0;
        }
        else
        {
            // Restaure o volume original.
            AudioListener.volume = savedVolume;
        }

        // Atualize a imagem do botão.
        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        if (buttonImage != null)
        {
            if (isMuted)
            {
                buttonImage.sprite = soundOffSprite; // Use a sprite de som desligado.
            }
            else
            {
                buttonImage.sprite = soundOnSprite; // Use a sprite de som ligado.
            }
        }
    }
}
