﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Launch
{ 
    public class ResourceLoader : MonoBehaviour
    {
        private static int MaxLoaderCount = 5;

        public event Action<Resource> OnDone;
        private InResourcesLoader _inResourcesLoader;
        private WWWResLoader _wwwLoader;
        private OutResourcesLoader _outResourcesLoader;
        private LinkedList<Resource> _waitingList;
        private LinkedList<Resource> _loadingList;
        private ResourceMgr _resMgr;

        public static ResourceLoader GetResLoader(GameObject go)
        {
            ResourceLoader loader = go.AddComponentOnce<ResourceLoader>();
            loader.Init();
            return loader;
        }

        protected void Init()
        {
            _resMgr = this.gameObject.AddComponentOnce<ResourceMgr>();
            _inResourcesLoader = this.gameObject.AddComponentOnce<InResourcesLoader>();
            _wwwLoader = this.gameObject.AddComponentOnce<WWWResLoader>();
            _outResourcesLoader = this.gameObject.AddComponentOnce<OutResourcesLoader>();
            _inResourcesLoader.OnResourceDone += OnResourceDone;
            _wwwLoader.OnResourceDone += OnResourceDone;
            _outResourcesLoader.OnResourceDone += OnResourceDone;

            _waitingList = new LinkedList<Resource>();
            _loadingList = new LinkedList<Resource>();
        }

        private void OnResourceDone(Resource res)
        {
            if(_loadingList.Count > 0 && _loadingList.First.Value == res)
            {
                while(_loadingList.Count > 0 && _loadingList.First.Value.isDone)
                {
                    Resource first = _loadingList.First.Value;
                    _loadingList.RemoveFirst();
                    if (OnDone != null)
                    {
                        OnDone.Invoke(first);
                    }
                }
            }
            LoadNext();
            //bool succ = _loadingList.Remove(res);
            //if (succ)
            //{
            //    if (OnDone != null)
            //    {
            //        OnDone.Invoke(res);
            //    }
            //}
            //LoadNext();
        }

        public void Load(Resource res)
        {
            if (_waitingList.Contains(res) || _loadingList.Contains(res))
                return;
            _waitingList.AddLast(res);
            LoadNext();
        }

        public bool IsWaitLoading(Resource res)
        {
            return _waitingList.Contains(res);
        }

        public bool RemoveWaitingLoadingRes(Resource res)
        {
            return _waitingList.Remove(res);
        }

        private void LoadNext()
        {
            while (_loadingList.Count < MaxLoaderCount && _waitingList.Count > 0)
            {
                Resource loadingRes = _waitingList.First.Value;
                _waitingList.RemoveFirst();
                _loadingList.AddLast(loadingRes);
                if (!_resMgr.ResourcesLoadMode)
                {
                    _wwwLoader.Load(loadingRes);
                }
                else
                {
                    _outResourcesLoader.Load(loadingRes);
                    //这里不用res目录
                    //_inResourcesLoader.Load(loadingRes);
                }
            }
        }

        void OnDestroy()
        {
            _inResourcesLoader.OnResourceDone -= OnResourceDone;
            _wwwLoader.OnResourceDone -= OnResourceDone;
            _outResourcesLoader.OnResourceDone -= OnResourceDone;
        }
    }
}