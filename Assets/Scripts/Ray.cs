using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector2 initialMousePos;
    Vector2 currentMousePos;
    EdgeCollider2D edgeCollider;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = this.GetComponent<EdgeCollider2D>();
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        SetEdgeCollider(lineRenderer);
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, new Vector3(initialMousePos.x, initialMousePos.y, 0f));
            lineRenderer.SetPosition(1, new Vector3(currentMousePos.x, currentMousePos.y, 0f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Circle(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }

    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < lineRenderer.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }

        edgeCollider.SetPoints(edges);
    }
}
