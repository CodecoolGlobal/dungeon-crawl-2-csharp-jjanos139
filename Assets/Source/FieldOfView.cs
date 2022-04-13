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

    public float viewDistance = 10f;
    private void LateUpdate()
    {
        float fov = 360f;
        int rayCount = 100;
        float angle = 0f;
        float angleIncrease = fov / rayCount;


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
                vertex = _origin + Utilities.GetVectorFromAngle(angle) * raycastHit2D.distance * 1.2f;

                if (Vector3.Distance(vertex, _origin) > viewDistance)
                {
                    vertex = Vector3.Normalize(vertex - _origin) * viewDistance + _origin;
                }
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

        _mesh.Clear();
        _mesh.vertices = vertices;
        _mesh.uv = uv;
        _mesh.triangles = triangles;
        _mesh.bounds = new Bounds(transform.position, Vector3.one * 1000f);
    }

    public void SetOrigin(Vector3 origin)
    {
        this._origin = origin;
        transform.position = Vector3.zero;
    }
}
