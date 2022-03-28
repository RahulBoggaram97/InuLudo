using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

namespace com.impactionalGames.LudoInu
{
    public class themeManager : MonoBehaviour
    {
        public static themeManager instance;
        public static event Action onThemeChanged;

        public Image _themeImage;

        private void Awake()
        {
            if(instance == null)
                instance = this;
        }

        public  void setTheme(Image thisImage)
        {
            _themeImage.sprite = thisImage.sprite;
            string path = GetSavePath();


            StartCoroutine( ConvertToPngAndSave(path));

        }

        private string GetSavePath()
        {
            string directoryPath = Application.persistentDataPath + "/" + "ThemeImages" + "/";

            if (!Directory.Exists(directoryPath))
            {
                //Create if it doesn't exist yet
                Directory.CreateDirectory(directoryPath);
                return directoryPath + "themebackGroundImage.png ";
            }

            return directoryPath + "themebackGroundImage.png ";

            
        }

        private IEnumerator ConvertToPngAndSave(string path)
        {
            yield return new WaitForFixedUpdate();
            //Convert to png
            byte[] bytes = _themeImage.sprite.texture.EncodeToPNG();
            //Save
            File.WriteAllBytes(path, bytes);

            playerPermData.setThemePath(path);

            onThemeChanged?.Invoke();
        }

        public static void ConvertToTextureAndLoad(GameObject backGroundImage)
        {
            string path =  playerPermData.getThemePath();
            Debug.Log(playerPermData.getThemePath());
            //Read
            byte[] bytes = File.ReadAllBytes(path);
            //Convert image to texture
            Texture2D loadTexture = new Texture2D(2, 2);
            loadTexture.LoadImage(bytes);
            //Convert textures to sprites

            if (backGroundImage.GetComponent<Image>() != null)
            {
              backGroundImage.GetComponent<Image>().sprite = Sprite.Create(loadTexture, new Rect(0, 0, loadTexture.width, loadTexture.height), Vector2.zero);
            }
            else if(backGroundImage.GetComponent<SpriteRenderer>() != null)
            {
                backGroundImage.GetComponent<SpriteRenderer>().sprite = Sprite.Create(loadTexture, new Rect(-3, -6, loadTexture.width, loadTexture.height), Vector2.zero);
            }
        }
    }
}
