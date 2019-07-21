using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    private Image _powerImage;

    // Use this for initialization
    void Start()
    {
        _powerImage = GetComponentInChildren<Image>();
        SpawnPoint.onPowerChanged += onPowerChanged;
    }

    private void OnDestroy()
    {
        SpawnPoint.onPowerChanged -= onPowerChanged;
    }

    public void onPowerChanged(float power)
    {
        _powerImage.fillAmount = power;
    }
}
