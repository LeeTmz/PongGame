using UnityEngine;
using UnityEngine.UI;

public class SelectBG : MonoBehaviour
{
    [SerializeField] private Texture[] textureBackGround;
    [SerializeField] private RawImage img;


    public void SelectTextureBackGround(int bgNumber) 
    {
        img.texture = textureBackGround[bgNumber];
    }

}
