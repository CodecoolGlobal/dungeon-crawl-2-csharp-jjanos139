using DungeonCrawl;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private Mesh _mesh;

    private Vector3 _origin;

    private void Start()
    {
        _origin = Vector3.zero;
        _mesh = new Mesh();
        _layerMask = LayerMask.GetMask("Objects");
        GetComponent<MeshFilter>().mesh = _mesh;
    }

    private void LateUpdate()
    {
        float fov = 360f;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 10f;


        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = _origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(_origin, Utilities.GetVectorFromAngle(angle), viewDistance, _layerMask.value);
            if (raycastHit2D.collider == null)
            {
                vertex = _origin + Utilities.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;

            angle -= angleIncrease;
        }

        _mesh.vertices = vertices;
        _mesh.uv = uv;
        _mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        this._origin = origin;
        transform.position = Vector3.zero;
    }
}
