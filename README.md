# UnitySerializeReference
### �g����
- SerializeReferenceEditor.cs ��Unity�v���W�F�N�g��Editor�t�H���_�ɔz�u���Ă��������B
- SerializeReferenceEditor.cs ��16�s�ڂ� MonoBehaviourEx �N���X���ASerializeReference�@�\���g�������N���X�ɓK�X���������Ă��������B
- �����ꂩ�̃R���|�[�l���g�X�N���v�g�ɁAAttribute: SerializeReference(path) ������GameObject�܂��̓R���|�[�l���g�^�̃t�B�[���h���`���Ă��������B
- Hierarchy��Ł��̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g��I�����AShift+R�L�[�������ƎQ�Ƃ������ŃZ�b�g���܂��B
- �Ⴆ�΁A�ȉ��̂悤�ȃt�B�[���h�����X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�gParent��I������Shift+R�������ƁA
```[SerializeField][SerializeReference("Node/Image")] protected Image m_Image
```
�ȉ��̐e�q�֌W�ɂ���Image�I�u�W�F�N�g�ɃA�^�b�`����Ă���Image�R���|�[�l���g�ւ̎Q�Ƃ�m_Image�ɃZ�b�g���܂��B
```Parent
��Node
�@��Image
```
