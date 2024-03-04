using UnityEngine;

public class RewardAds : MonoBehaviour
{
    private int _money;

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnRewardCallback()
    {
        _money++;
    }

    private void OnCloseCallback()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}
