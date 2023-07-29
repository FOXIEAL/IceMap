using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements; // UIElements�̖��O��Ԃ�ǉ�

public class OnClickdebug : MonoBehaviour
{
    private UnityEngine.UI.Toggle toggle; // UnityEngine.UI.Toggle�𖾎��I�Ɏw��

    private void Start()
    {
        // UnityEngine.UI.Toggle�R���|�[�l���g���擾
        toggle = GetComponent<UnityEngine.UI.Toggle>();

        if (toggle == null)
        {
            // UIElements.Toggle�R���|�[�l���g���A�^�b�`����Ă���ꍇ�A���̃X�N���v�g�ł͑Ή����Ă��Ȃ��|������
            Debug.LogError("Toggle�R���|�[�l���g���A�^�b�`����Ă��܂���BUnityEngine.UI.Toggle��GameObject�ɃA�^�b�`���Ă��������B");
            return;
        }

        // Toggle��onValueChanged�C�x���g�Ƀ��\�b�h��o�^
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        // Toggle���N���b�N���ꂽ�ۂɌĂяo����郁�\�b�h
        Debug.Log("Toggle���N���b�N����܂����B���݂̏��: " + isOn);
    }

    private void OnDestroy()
    {
        // �C�x���g���X�i�[�̉���
        if (toggle != null)
        {
            toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    }
}

