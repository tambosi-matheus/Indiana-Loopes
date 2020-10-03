// Maded by Pedro M Marangon
using UnityEngine;

namespace IndianaLoopes.Animations
{

    [System.Serializable]
    public enum AnimationString
	{
        Idle,
        Walk
	}

    [System.Serializable]
    public struct Animations
	{
        public string name;
        public AnimationString type;
	}

    public class AnimationsController : MonoBehaviour
    {

        [SerializeField] private Animator anim = null;

		[SerializeField] private Animations[] animations = new Animations[0];

		// Start is called before the first frame update
		void Awake()
        {
            if (!anim) anim = GetComponentInChildren<Animator>();
        }

        public void SetAnimation(AnimationString animation)
		{
			foreach (Animations a in animations)
			{
                if (!a.type.Equals(animation) ||
                    anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals(a.name)) continue;

                anim?.Play(a.name);
                break;
			}
		}
    }

}