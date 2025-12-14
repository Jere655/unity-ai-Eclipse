using UnityEngine;
using System;

[Serializable]
public class AICommand
{
    public string shape;
    public float[] position;
    public float[] scale;
}

public class SceneExecutor : MonoBehaviour
{
    public void Execute(string json)
    {
        AICommand cmd = JsonUtility.FromJson<AICommand>(json);

        GameObject obj = GameObject.CreatePrimitive(
            cmd.shape == "sphere" ? PrimitiveType.Sphere : PrimitiveType.Cube
        );

        obj.transform.position = new Vector3(cmd.position[0], cmd.position[1], cmd.position[2]);
        obj.transform.localScale = new Vector3(cmd.scale[0], cmd.scale[1], cmd.scale[2]);
    }
}
