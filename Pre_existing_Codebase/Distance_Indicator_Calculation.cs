using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Indicator_Calculation : MonoBehaviour {

    public GameObject indicator_cv_zone_mesh;
    // Eckpunkte cv_zone
    public GameObject cv_zone_point0;
    public GameObject cv_zone_point1;
    public GameObject cv_zone_point2;
    public GameObject cv_zone_point3;
    public GameObject cv_zone_point4;
    public GameObject cv_zone_point5;
    public GameObject cv_zone_point6;

    //public Material material_red_zone;

    MeshFilter mf_cv_zone;
    Mesh mesh_cv_zone;

    Vector3[] vertices_cv_zone;
    int[] triangles_cv_zone;


    public GameObject indicator_fv_zone_mesh;
    // Eckpunkte fv_zone
    public GameObject fv_zone_point0;
    public GameObject fv_zone_point1;
    public GameObject fv_zone_point2;
    public GameObject fv_zone_point3;
    public GameObject fv_zone_point4;
    public GameObject fv_zone_point5;
    public GameObject fv_zone_point6;
    public GameObject fv_zone_point7;

    public GameObject fv_zone_point8;
    public GameObject fv_zone_point9;
    public GameObject fv_zone_point10;
    public GameObject fv_zone_point11;
    public GameObject fv_zone_point12;
    public GameObject fv_zone_point13;
    

    MeshFilter mf_fv_zone;
    Mesh mesh_fv_zone;

    Vector3[] vertices_fv_zone;
    int[] triangles_fv_zone;




    // Use this for initialization

    void Start ()
    {
        mf_cv_zone = indicator_cv_zone_mesh.GetComponent<MeshFilter>();
        mesh_cv_zone = mf_cv_zone.mesh;

        mf_fv_zone = indicator_fv_zone_mesh.GetComponent<MeshFilter>();
        mesh_fv_zone = mf_fv_zone.mesh;

        draw_distance_indication_zones();




    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void draw_distance_indication_zones()
    {
        draw_mesh_cv_zone();
        draw_mesh_fv_zone();
    }

    public void draw_mesh_cv_zone()
    {
        vertices_cv_zone = new Vector3[]
        {
            cv_zone_point0.transform.localPosition,
            cv_zone_point1.transform.localPosition,
            cv_zone_point2.transform.localPosition,
            cv_zone_point3.transform.localPosition,
            cv_zone_point4.transform.localPosition,
            cv_zone_point5.transform.localPosition,
            cv_zone_point6.transform.localPosition     
        };

        triangles_cv_zone = new int[]
        {
            0,1,3,      // Dreieck 1
            1,2,3,      // Dreieck 2
            0,3,4,       // Dreieck 3
            6,4,5,       // Dreieck 4
            6,0,4       // Dreieck 5
        };
        //Mesh myMesh = new Mesh();
        mesh_cv_zone.Clear();
        mesh_cv_zone.vertices = vertices_cv_zone;
        mesh_cv_zone.triangles = triangles_cv_zone;
        //mesh.normals = normals;
        //mesh.uv = UV;
        mesh_cv_zone.RecalculateNormals();
        //myMesh.Optimize();
    
    }

    public void draw_mesh_fv_zone()
    {
        vertices_fv_zone = new Vector3[]
        {
            fv_zone_point0.transform.localPosition,
            fv_zone_point1.transform.localPosition,
            fv_zone_point2.transform.localPosition,
            fv_zone_point3.transform.localPosition,
            fv_zone_point4.transform.localPosition,
            fv_zone_point5.transform.localPosition,
            fv_zone_point6.transform.localPosition,
            fv_zone_point7.transform.localPosition,

            fv_zone_point8.transform.localPosition,
            fv_zone_point9.transform.localPosition,
            fv_zone_point10.transform.localPosition,
            fv_zone_point11.transform.localPosition,
            fv_zone_point12.transform.localPosition,
            fv_zone_point13.transform.localPosition
            


        };

        triangles_fv_zone = new int[]
        {
            0,1,2,      // Dreieck 1
            0,2,3,      // Dreieck 2
            0,3,4,       // Dreieck 3
            0,4,5,       // Dreieck 4
            0,5,6,       // Dreieck 5
            0,6,7,       // Dreieck 6

            0,7,8,      // Dreieck 7
            0,8,9,      // Dreieck 8
            0,9,10,       // Dreieck 9
            0,10,11,       // Dreieck 10
            0,11,12,       // Dreieck 11
            0,12,13       // Dreieck 12
        };
        //Mesh myMesh = new Mesh();
        mesh_fv_zone.Clear();
        mesh_fv_zone.vertices = vertices_fv_zone;
        mesh_fv_zone.triangles = triangles_fv_zone;
        //mesh.normals = normals;
        //mesh.uv = UV;
        mesh_fv_zone.RecalculateNormals();
        //myMesh.Optimize();
    }

}
