using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SerializeReferenceEditor : EditorWindow
{
	[MenuItem("Tools/Serialize/SetReference #r")]
	static void SetReference()
	{
		foreach(var obj in Selection.gameObjects)
		{
			Undo.RegisterCompleteObjectUndo(obj, "SetReference");
			// MonoBehaviourExはプロジェクトで使うMonoBehaviourのラッパに適宜差し替え（自作スクリプトのみを対象とするため）
			MonoBehaviourEx[] componentList = obj.GetComponents<MonoBehaviourEx>();
			foreach(var component in componentList)
			{
				Type componentType = component.GetType(); // 取得した各Componentの型情報
				foreach(var field in componentType.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic))
				{
					// フィールドのうちSerializeReferenceがついているもののみ処理（SerializeReferenceはMultiple禁止）
					SerializeReferenceAttribute attribute = Attribute.GetCustomAttribute(field, typeof(SerializeReferenceAttribute)) as SerializeReferenceAttribute;
					if(attribute != null)
					{
						Transform referenceTarget = null;
						if(attribute.Path.Length > 0)
						{
							referenceTarget = obj.transform.Find(attribute.Path);
						}
						else
						{
							// 空文字の場合は自分自身
							referenceTarget = obj.transform;
						}
						if(referenceTarget != null)
						{
							// 対象がGameObjectおよびその派生はそのままセット
							if(field.FieldType == typeof(GameObject) || field.FieldType.IsSubclassOf(typeof(GameObject)))
							{
								field.SetValue(component, referenceTarget.gameObject);
							}
							// 対象がComponentならGetComponentしてセット
							else if(field.FieldType.IsSubclassOf(typeof(Component)))
							{
								var referenceTargetComponent = referenceTarget.gameObject.GetComponent(field.FieldType);
								if(referenceTargetComponent != null)
								{
									field.SetValue(component, referenceTargetComponent);
								}
								else
								{
									// 欲しい型のComponentがアタッチされていなかった
									Debug.LogError("SerializeReference/Set: " + obj.name + " -> " + attribute.Path + " のコンポーネント " + field.FieldType.ToString() + " が取得できませんでした。");
									field.SetValue(component, null);
								}
							}
							// それ以外にSerializeReferenceを指定するのはだめ
							else
							{
								Debug.LogError("SerializeReference/Set: " + obj.name + " -> " + attribute.Path + " の型 " + field.FieldType.ToString() + " がGameObjectでもComponentでもありません。");
							}
						}
						else
						{
							// 指定したパスのオブジェクトが存在しないのはだめ
							Debug.LogError("SerializeReference/Set: " + obj.name + " -> " + attribute.Path + " が取得できませんでした。");
						}
					}
				}
			}
			EditorUtility.SetDirty(obj);
		}
	}
}
