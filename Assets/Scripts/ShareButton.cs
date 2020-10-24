using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{
    public void ClickShare() {
        StartCoroutine(Share());
        //da pošlje že prej pripravljeno sliko
        //StartCoroutine(ShareSlika());
    }
    private IEnumerator Share()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Black and White").SetText("I just found this awesome game! Can you beat my highscore? Download link: https://play.google.com/store/apps/details?id=com.mazejgames.blackandwhite").Share();
        //sam slika da pošlje
        //new NativeShare().AddFile(filePath).Share();

    }
    /*private IEnumerator ShareSlika()
    {
        Texture2D slika = Resources.Load("image", typeof(Texture2D)) as Texture2D;

        yield return null;

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, slika.EncodeToPNG());

        new NativeShare().AddFile(filePath).Share();
    }*/
}
