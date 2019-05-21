# UnitySerializeReference
### 使い方
- SerializeReferenceEditor.cs をUnityプロジェクトのEditorフォルダに配置してください。
- SerializeReferenceEditor.cs の16行目の MonoBehaviourEx クラスを、SerializeReference機能を使いたいクラスに適宜書き換えてください。
- いずれかのコンポーネントスクリプトに、Attribute: SerializeReference(path) をもつGameObjectまたはコンポーネント型のフィールドを定義してください。
- Hierarchy上で↑のスクリプトがアタッチされたオブジェクトを選択し、Shift+Rキーを押すと参照を自動でセットします。
- 例えば、以下のようなフィールドをもつスクリプトがアタッチされたオブジェクトParentを選択してShift+Rを押すと、
```
[SerializeField][SerializeReference("Node/Image")] protected Image m_Image
```
以下の親子関係にあるImageオブジェクトにアタッチされているImageコンポーネントへの参照をm_Imageにセットします。
```Parent
└Node
　└Image
```
