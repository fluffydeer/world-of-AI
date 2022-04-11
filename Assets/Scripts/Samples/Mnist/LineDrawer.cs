using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BarracudaSample
{
    //automatically adds required components to the gameobject
    [RequireComponent(typeof(RawImage), typeof(EventTrigger))]
    //IDragHandler is an interface which kets us receive OnDrag callbacks
    public class LineDrawer : MonoBehaviour, IDragHandler
    {

        //trieda z ktorej tahame jednu metodu
        [System.Serializable]
        //RenderTexture is a texture that can be rendered to
        public class DrawEvent : UnityEvent<RenderTexture>  
        {
        }

        //Vector2Int - representation of vector and points using integers
        [SerializeField] Vector2Int imageDimention = new Vector2Int(28, 28);
        [SerializeField] Color paintColor = Color.white;
        [SerializeField] RenderTextureFormat format = RenderTextureFormat.R8;   //??

        //toto neviem co je, lebo si nikde nedefinujeme addlistener, cize nevim aku funkciu to spusta na invoke
        [SerializeField] DrawEvent OnDraw = new DrawEvent();        //toto nam umozni vidiet/pridat eventy v inspectore do componentu
        //je tam pretiahnuty Minst.Execute skript, cize vzdy ak sa spusti OnDraw tak to spusti excecute
        //ciiiizee vzdy ak sa spusti OnDrag event tak sa spusti OnDraw event, ktory spusti execute 


        RawImage imageView = null;      //displays a texture2D for the UI
        //texture2d is used to create and modify textures

        Mesh lineMesh;
        Material lineMaterial;
        Texture2D clearTexture;

        public RenderTexture texture;

        void OnEnable()
        {
            imageView = GetComponent<RawImage>();

            lineMesh = new Mesh();
            lineMesh.MarkDynamic();
            lineMesh.vertices = new Vector3[2]; //toto su indexy 0 a 1 dole v riadku SetIndices
            //Sets the index buffer for the sub-mesh.
            //index buffer is an array of pointers into the vertex buffer - stores indices
            //vertex buffer stores vertices
            lineMesh.SetIndices(new[] { 0, 1 }, MeshTopology.Lines, 0); //Each two indices in the mesh index buffer form a line.
            lineMaterial = new Material(Shader.Find("Hidden/LineShader"));
            lineMaterial.SetColor("_Color", paintColor);

            texture = new RenderTexture(imageDimention.x, imageDimention.y, 0, format);
            texture.filterMode = FilterMode.Bilinear;
            imageView.texture = texture;

            clearTexture = Texture2D.blackTexture;

            var trigger = GetComponent<EventTrigger>();
        }

        void Start()
        {
            ClearTexture();
        }

        void OnDisable()
        {
            texture?.Release();
            Destroy(lineMesh);
            Destroy(lineMaterial);
        }

        public void ClearTexture()
        {
            Graphics.Blit(clearTexture, texture);
        }

//ja budem musiet tuto funkciu bud volat z vonka alebo ju vyemnit za nieco
//co ju nahradi vo vr
//mozno ak hrac chyti fixku? spustila by ta fixka ondrag event? 
//alebo nejako simulovat PointerEventData z VR - asi nemozne kedze to pyta aj click count a take kkcinky
//tak potom simulovat len tie data, ktore realne potrebujeme - data.pointerDrag, position a delta
        private void OnTriggerEnter(Collider other) {
            Debug.Log(other.name);
            if(other.name == "finger_index_2_r"){
                Debug.Log("DOTYKAM SA PLATNAA");
                Vector3 data_position = other.transform.position;
            }
        }


        //vo vr nefunguje ondrag cize by sme museli tie data posielat inak
        //asi vzdy ked sa oznaci quad tak by sa vyfarbil pixel - ta ciara by sa musela
        //kreslit od posledneho bodu a neviem jak by som si ich ukladala
        public void OnDrag(PointerEventData data)
        {
            data.Use();     //uses the event
            //data position je pozicia bodu vo world space, ked rodicom nie je nic
            //tieto data by bolo fajn vypisat a nasledne imitovat vo vr!!!!
            var area = data.pointerDrag.GetComponent<RectTransform>();
            Debug.Log("data.position " + data.position);   //globalna
            Debug.Log("data.delta " + data.delta);
            //returns the gameobject the script is attached to
            //pointerDrag -> the object that is receiving OnDrag, which in our case is the InputTexture
            //print our the name!!! it can be easily exchanged for out canvas in vr
            //delta je zmena - dlzka ktora prejde od zacatia tahu
            var p0 = area.InverseTransformPoint(data.position - data.delta);    //t.j. data position bolo vo world space a davame ho do local space
            //do local space objektu, ktory ma tento skript na sebe pripevneny
            //pointer position in vector2, window based, zero zero bottom left
            //delta - pointer data since last update, Vector2
            var p1 = area.InverseTransformPoint(data.position);
            Debug.Log("po konverzii zo world space p0: " + p0 + " p1: " + p1);  //cize p0 a p1 su momentalne v local space
            //dlzka a sirka su width a height z rect transform
            Debug.Log("width " + area.rect.width);
            Debug.Log("height " + area.rect.height);
            //tento scale nie je 0,0,0 ale 0.003 a to ked sa spravi skalarny sucet s vektorom tak vyjde to dolne p0
            var scale = new Vector3(2 / area.rect.width, -2 / area.rect.height, 0);

            Debug.Log("scale " + scale);
            p0 = Vector3.Scale(p0, scale);  //multiplies two vectors scalar
            p1 = Vector3.Scale(p1, scale);

            Debug.Log("po aplikovani scale p0: " + p0 + " p1: " + p1);
            DrawLine(p0, p1);
            

            OnDraw.Invoke(texture); //invokes MnistSample.Execute
        }

        void DrawLine(Vector3 p0, Vector3 p1)
        {
            var prevRT = RenderTexture.active;  //previous render texture
            RenderTexture.active = texture;

            lineMesh.SetVertices(new List<Vector3>() { p0, p1 });       //nastavime meshku
            lineMaterial.SetPass(0);                                    //	Shader pass number to setup.
            Graphics.DrawMeshNow(lineMesh, Matrix4x4.identity);         //tunak nam nakresli nastavenu meshku
            //kedy z toho presne spravi ciaru - v enable

            RenderTexture.active = prevRT;
        }
    }
}
