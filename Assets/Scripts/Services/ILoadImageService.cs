using System.Threading.Tasks;
using UnityEngine;

namespace View.UI
{
    public interface ILoadImageService
    {
        Task<Sprite> GetRemoteTexture(string url);
    }
}