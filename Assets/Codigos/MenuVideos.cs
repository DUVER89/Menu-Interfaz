using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;   // <- si quieres usar TextMeshPro

public class MenuVideos : MonoBehaviour
{
    [System.Serializable]
    public class VideoInfo
    {
        public string nombreArchivo;   // nombre del archivo en StreamingAssets
        public string descripcion;     // texto asociado al video
    }

    public VideoInfo[] videos;          // array de videos con descripción
    public VideoPlayer videoPlayer;     // referencia al componente VideoPlayer
    public TMP_Text textoDescripcion;   // referencia al texto en la UI

    private int indiceActual = 0;

    void Start()
    {
        ReproducirVideo(indiceActual);
    }

    public void CambiarVideo(int direccion)
    {
        indiceActual += direccion;

        if (indiceActual < 0) indiceActual = videos.Length - 1;
        if (indiceActual >= videos.Length) indiceActual = 0;

        ReproducirVideo(indiceActual);
    }

    void ReproducirVideo(int index)
    {
        string ruta = System.IO.Path.Combine(Application.streamingAssetsPath, videos[index].nombreArchivo);
        videoPlayer.url = ruta;

        Debug.Log("Reproduciendo: " + ruta);

        videoPlayer.Play();

        // actualizar el texto
        if (textoDescripcion != null)
        {
            textoDescripcion.text = videos[index].descripcion;
        }
    }
}
