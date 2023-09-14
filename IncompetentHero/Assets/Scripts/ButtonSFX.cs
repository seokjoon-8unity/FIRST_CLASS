using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    public void PlaySFX() {
        SoundManager.GetInstance().PlaySFX(_clip);
    }
}
