using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    enum SoundType {
        BGM,
        SFX
    }
    [SerializeField] private SoundType _type;
    Slider _slider;

    private void Awake() {
        _slider = GetComponent<Slider>();
    }

    private void LateUpdate() {
        switch(_type) {
            case SoundType.BGM:
                SoundManager.GetInstance().ChangeVolume(true, _slider.value);
                break;
            case SoundType.SFX:
                SoundManager.GetInstance().ChangeVolume(false, _slider.value);
                break;
        }
    }
}
