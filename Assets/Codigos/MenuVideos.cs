using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class MenuVideos : MonoBehaviour
{
    [System.Serializable]
    public class VideoInfo
    {
        public string nombreArchivo;   // nombre del archivo en StreamingAssets

        [TextArea(2, 5)]               // 👉 ahora la descripción se edita en varias líneas en el Inspector
        public string descripcion;     // texto asociado al video
    }

    public VideoInfo[] videos;          // array de videos con descripción
    public VideoPlayer videoPlayer;     // referencia al componente VideoPlayer
    public TMP_Text textoDescripcion;   // referencia al texto en la UI

    private int indiceActual = 0;
    private bool enPausa = false;       // 👉 para saber si el video está pausado

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
        enPausa = false; // cuando cambia de video siempre se reproduce

        // actualizar el texto
        if (textoDescripcion != null)
        {
            textoDescripcion.text = videos[index].descripcion;
        }
    }

    // 👉 Este método lo asignas al botón Pause/Reanudar
    public void PausarReanudar()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            enPausa = true;
            Debug.Log("Video en pausa");
        }
        else if (enPausa)
        {
            videoPlayer.Play();
            enPausa = false;
            Debug.Log("Video reanudado");
        }
    }
}


