using UnityEngine;

public class HoverSoundScript : MonoBehaviour
{
    private void OnMouseEnter()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayHoverSound();
        }
    }

    private void OnMouseDown()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayClickSound();
        }
    }
}
