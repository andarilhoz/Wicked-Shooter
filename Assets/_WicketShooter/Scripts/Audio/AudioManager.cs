using UnityEngine;
using UnityEngine.UI;

namespace _WicketShooter.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Button AudioToggle;
        public Image AudioToggleImage;
        public Sprite MuteSprite;
        public Sprite AudioSprite;

        public AudioSource AudioSource;

        private const string VOLUME_PLAYERPREFS_KEY = "VOLUME";
        private bool mute = false;
        private float volume;

        private void Start()
        {
            volume = PlayerPrefs.GetFloat(VOLUME_PLAYERPREFS_KEY, .8f);
            AudioToggle.onClick.AddListener(ToggleAudio);
        }

        private void ToggleAudio()
        {
            mute = !mute;
            AudioToggleImage.sprite = mute ? MuteSprite : AudioSprite;
        }

        public void PlayAudio(AudioClip audioClip)
        {
            AudioSource.PlayOneShot(audioClip);
        }
    }
}