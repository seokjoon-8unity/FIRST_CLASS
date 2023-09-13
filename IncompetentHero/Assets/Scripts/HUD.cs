using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public HUDType type;
    private Slider _slider;

    public GameObject[] _buffs;
    private TMP_Text[] _texts;
    public Image[] _buffCoverImages;


    private void Awake() {
        _slider = GetComponent<Slider>();
        if(type == HUDType.BUFF) {
            _buffs = new GameObject[System.Enum.GetValues(typeof(BuffType)).Length];
            _texts = new TMP_Text[_buffs.Length];
            _buffCoverImages = new Image[_buffs.Length];

            for (int i = 0; i < _buffs.Length; i++) {
                _buffs[i] = transform.GetChild(i).gameObject;
                _texts[i] = _buffs[i].GetComponentInChildren<TMP_Text>();
                _buffCoverImages[i] = _buffs[i].GetComponentInChildren<Image>();
            }
        }
    }

    private void LateUpdate() {
        switch(type) {
            case HUDType.LIFE:
                int hp = GameManager.GetInstance().HP;
                for(int i = 0; i < transform.childCount; i++) {
                    if(transform.GetChild(i).gameObject.activeSelf) {
                        hp--;
                    }
                }

                // 현재 체력 < 표기된 체력
                if(hp < 0) {
                    for(int i = 0; i < transform.childCount; i++) {
                        if(transform.GetChild(i).gameObject.activeSelf) {
                            transform.GetChild(i).gameObject.SetActive(false);
                            break;
                        }
                    }
                    
                }
                // 현재 체력 > 표기된 체력
                else if(hp > 0) {
                    GameManager.GetInstance().PoolManager.GetItemWithIndex(2).transform.parent = transform;
                }

                break;
            case HUDType.TIMER:
                _slider.value = GameManager.GetInstance().GameTime / GameManager.GetInstance().MaxTime;
                break;
            case HUDType.BUFF:
                for(int i = 0; i < _buffs.Length; i++) {
                    BuffSO buff = GameManager.GetInstance().BuffManager.GetBuffSO(i);

                    if(_buffs[i].activeSelf) {
                        if(buff.buffTick <= 0) {
                            _buffs[i].SetActive(false);
                        }
                        else {
                            _texts[i].text = Mathf.CeilToInt(buff.buffTick).ToString("D");
                            _buffCoverImages[i].fillAmount = buff.buffTick / buff.buffDuration;
                        }
                    }
                    else {
                        if(buff.buffTick > 0) {
                            _buffs[i].SetActive(true);
                            _texts[i].text = Mathf.CeilToInt(buff.buffTick).ToString("D");
                            _buffCoverImages[i].fillAmount = buff.buffTick / buff.buffDuration;
                        }
                    }
                }
                break;
        }
    }
    
}
