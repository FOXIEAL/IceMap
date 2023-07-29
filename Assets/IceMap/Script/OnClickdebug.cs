using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements; // UIElementsの名前空間を追加

public class OnClickdebug : MonoBehaviour
{
    private UnityEngine.UI.Toggle toggle; // UnityEngine.UI.Toggleを明示的に指定

    private void Start()
    {
        // UnityEngine.UI.Toggleコンポーネントを取得
        toggle = GetComponent<UnityEngine.UI.Toggle>();

        if (toggle == null)
        {
            // UIElements.Toggleコンポーネントがアタッチされている場合、このスクリプトでは対応していない旨を示す
            Debug.LogError("Toggleコンポーネントがアタッチされていません。UnityEngine.UI.ToggleをGameObjectにアタッチしてください。");
            return;
        }

        // ToggleのonValueChangedイベントにメソッドを登録
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        // Toggleがクリックされた際に呼び出されるメソッド
        Debug.Log("Toggleがクリックされました。現在の状態: " + isOn);
    }

    private void OnDestroy()
    {
        // イベントリスナーの解除
        if (toggle != null)
        {
            toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    }
}

