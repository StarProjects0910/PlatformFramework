﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Launch_CTLResourceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("CTLResource");
		L.RegFunction("GetResource", GetResource);
		L.RegFunction("ReleaseUnUseRes", ReleaseUnUseRes);
		L.RegFunction("RemoveListener", RemoveListener);
		L.RegFunction("RemoveAllListener", RemoveAllListener);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetResource(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			Launch.ResourceMgr.ResourceHandler arg2 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (Launch.ResourceMgr.ResourceHandler)ToLua.CheckObject(L, 3, typeof(Launch.ResourceMgr.ResourceHandler));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				arg2 = DelegateFactory.CreateDelegate(typeof(Launch.ResourceMgr.ResourceHandler), func) as Launch.ResourceMgr.ResourceHandler;
			}

			Launch.CTLResource.GetResource(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReleaseUnUseRes(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			Launch.CTLResource.ReleaseUnUseRes(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveListener(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			Launch.ResourceMgr.ResourceHandler arg2 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (Launch.ResourceMgr.ResourceHandler)ToLua.CheckObject(L, 3, typeof(Launch.ResourceMgr.ResourceHandler));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				arg2 = DelegateFactory.CreateDelegate(typeof(Launch.ResourceMgr.ResourceHandler), func) as Launch.ResourceMgr.ResourceHandler;
			}

			Launch.CTLResource.RemoveListener(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAllListener(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			Launch.CTLResource.RemoveAllListener(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

