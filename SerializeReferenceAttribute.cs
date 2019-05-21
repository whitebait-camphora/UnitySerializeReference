using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field)]
public class SerializeReferenceAttribute : Attribute
{
	public string Path { get; private set; }
	public SerializeReferenceAttribute(string path) { Path = path; }
	public SerializeReferenceAttribute() { Path = ""; }
}
