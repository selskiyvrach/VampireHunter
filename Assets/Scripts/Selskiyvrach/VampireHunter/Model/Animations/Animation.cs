using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

namespace Selskiyvrach.VampireHunter.Model.Animations
{
    public abstract class Animation
    {
        public abstract void Play();
    }

    public interface IAnimationCallback<T> where T : AnimationCallback
    {
        void AddCallbackListener(Action<T> listener);
        void RemoveCallbackListener(Action<T> listener);
    }

    public abstract class Animation<TCallback> :  Animation, IAnimationCallback<TCallback> where TCallback : AnimationCallback
    {
        private event Action<TCallback> OnCallback;
        
        public void AddCallbackListener(Action<TCallback> listener) => 
            OnCallback += listener;

        public void RemoveCallbackListener(Action<TCallback> listener) => 
            OnCallback -= listener;

        protected void RaiseOnCallback(TCallback obj) => 
            OnCallback?.Invoke(obj);
    }

    public interface IReloadCallback : IAnimationCallback<ReloadedAnimationCallback>
    {
        
    }

    public interface IHammerCockedCallback : IAnimationCallback<HammerCockedCallback>
    {
    }
    
    public class MultiCallbackAnimationExample : Animation, IReloadCallback, IHammerCockedCallback
    {
        public override void Play()
        {
        }

        public void AddCallbackListener(Action<ReloadedAnimationCallback> listener)
        {
        }

        public void RemoveCallbackListener(Action<ReloadedAnimationCallback> listener)
        {
        }

        public void AddCallbackListener(Action<HammerCockedCallback> listener)
        {
        }

        public void RemoveCallbackListener(Action<HammerCockedCallback> listener)
        {
        }
    }

    public class HammerCockedCallback : AnimationCallback
    {
    }

    public class ReloadedAnimationCallback : AnimationCallback
    {
    }

    public abstract class AnimationCallback
    {
        
    }

    public class AnimationsPlayer
    {
        private readonly Dictionary<Type, Animation> _animations = new Dictionary<Type, Animation>();

        public void AddCallbackListener<T>(Action<T> listener) where T : AnimationCallback => 
            _animations.Values.OfType<Animation<T>>()
                .ForEach(n => n.AddCallbackListener(listener));
        
        public void RemoveCallbackListener<T>(Action<T> listener) where T : AnimationCallback =>
            _animations.Values.OfType<Animation<T>>()
                .ForEach(n => n.RemoveCallbackListener(listener));

        public void Play<T>() where T : Animation => 
            _animations[typeof(T)].Play();

        public bool HasAnimation<T>() where T : Animation =>
            _animations.ContainsKey(typeof(T));
    }
}