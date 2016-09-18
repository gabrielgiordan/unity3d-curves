using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Ellipse : MonoBehaviour
{
  public LineRenderer ellipseLineRenderer;
  public int ellipseVertexCount = 25;
  public float ellipseScaleX = 2f;
  public float ellipseScaleY = 2f;
  public float ellipseRadius = 2f;
	
  void OnRenderObject()
  {
    ellipseLineRenderer.SetVertexCount(ellipseVertexCount);

    Vector3[] positions = new Vector3[ellipseVertexCount];

    float sineWave = Mathf.PI * ellipseRadius;
    float angleOffset = sineWave / (ellipseVertexCount - 1);

    for (int i = ellipseVertexCount; i-- > 0;)
    {
      float angle = angleOffset * i;
      float x = Mathf.Sin(angle) * ellipseScaleX;
      float y = Mathf.Cos(angle) * ellipseScaleY;

      positions[i] = new Vector3(x, y);
    }

    ellipseLineRenderer.SetPositions(positions);
  }
}
