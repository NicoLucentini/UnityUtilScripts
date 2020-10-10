using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public interface StaticSerializable {
}
public class StaticSerializableBuilder 
{

    public static T GetValuesFromStatic<T,K>() where T : StaticSerializable, new() {

        Type otherType = typeof(K);

        T response = new T();

        Type myType = typeof(T);

        FieldInfo[] otherfields = otherType.GetFields();
        FieldInfo[] myFields = myType.GetFields();

        foreach (var f1 in otherfields)
        {
            foreach (var f2 in myFields)
            {
                if (f1.Name == f2.Name)
                {
                    f2.SetValue(response, f1.GetValue(null));
                }
            }
        }

        return response;

    }
    public static void SetValuesToStatic<T, K>(T other) where T : StaticSerializable, new()
    {

        Type otherType = typeof(K);
        Type myType = typeof(T);

        FieldInfo[] otherfields = otherType.GetFields(BindingFlags.Static | BindingFlags.Public);
        FieldInfo[] myFields = myType.GetFields();

        foreach (var f1 in otherfields)
        {
            foreach (var f2 in myFields)
            {
                if (f1.Name == f2.Name)
                {
                    f1.SetValue(null, f2.GetValue(other));
                }
           }
        }


    }

}
