using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LemniscateOfBooth : MonoBehaviour
{

  public LineRenderer lineRenderer;
  public int lineVertexCount = 25;
  public float lineLength = 2f;
  public float lineScaleX = 2f;
  public float lineScaleY = 2f;
  public float lineScaleZ = 2f;
  public float frequency = 1f;
  public float a = 1.5f;
  public float b = 1f;

  void OnRenderObject()
  {
    lineRenderer.SetVertexCount(lineVertexCount);

    Vector3[] positions = new Vector3[lineVertexCount];

    float sineWave = Mathf.PI * lineLength;
    float angleOffset = sineWave / (lineVertexCount - 1);

    for (int i = lineVertexCount; i-- > 0;)
    {
      // x = b * (sin(t) / 1 + (a^2/b^2) * cos(t)^2)
      // y = a * ((sin(t) * cos(t)) / 1 + (a^2/b^2) * cos(t)^2)

      float angle = angleOffset * i;
      float t = angle + Time.time * frequency;
      float denominator = 1 + (Mathf.Pow(a, 2f) / Mathf.Pow(b, 2f) * Mathf.Pow(Mathf.Cos(t), 2f));
      float x = b * (Mathf.Sin(t) / denominator);
      float y = a * ((Mathf.Sin(t) * Mathf.Cos(t)) / denominator);
      float z = 0f;

      positions[i] = new Vector3(x, y, z);
    }

    lineRenderer.SetPositions(positions);
  }

}
