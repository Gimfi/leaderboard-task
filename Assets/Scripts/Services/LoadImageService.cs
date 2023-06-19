using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine;

namespace View.UI
{
    public class LoadImageService : ILoadImageService
    {
        private Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();

        public async Task<Sprite> GetRemoteTexture(string url)
        {
            if (_sprites.TryGetValue(url, out Sprite cacheSprite))
            {
                return cacheSprite;
            }
            else
            {
                using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
                {
                    UnityWebRequestAsyncOperation asyncOp = www.SendWebRequest();
                    while (asyncOp.isDone == false)
                    {
                        await Task.Delay(100);
                    }

                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
                    _sprites.Add(url, sprite);

                    return sprite;
                }
            }
        }
    }
}