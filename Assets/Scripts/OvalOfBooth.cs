using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class OvalOfBooth : MonoBehaviour
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
      // x = b * ((a * b * cos(t)) / (b^2 * cos(t)^2 + a^2 * sin(t)^2))
      // y = a * ((a * b * sin(t)) / (b^2 * cos(t)^2 + a^2 * sin(t)^2))

      float angle = angleOffset * i;
      float t = angle + Time.time * frequency;
      float denominator = Mathf.Pow(b, 2f) * Mathf.Pow(Mathf.Cos(t), 2f) + Mathf.Pow(a, 2f) * Mathf.Pow(Mathf.Sin(t), 2f);
      float x = b * ((a * b * Mathf.Cos(t)) / denominator);
      float y = a * ((a * b * Mathf.Sin(t)) / denominator);
      float z = 0f;

      positions[i] = new Vector3(x, y, z);
    }

    lineRenderer.SetPositions(positions);
  }

}
