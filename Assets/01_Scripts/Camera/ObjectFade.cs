using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    private Material mat;
    private Color originalColor;
    private bool isFaded = false;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
    }

    public void FadeOut()
    {
        if (isFaded) return;
        isFaded = true;

        Color c = mat.color;
        c.a = 0.3f; // 투명
        mat.color = c;
    }

    public void FadeIn()
    {
        if (!isFaded) return;
        isFaded = false;

        mat.color = originalColor; // 원래 색상 복구
    }
}