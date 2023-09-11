using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public HUDType type;
    private Slider _slider;

    private void Awake() {
        _slider = GetComponent<Slider>();
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

                break;
        }
    }
    
}
