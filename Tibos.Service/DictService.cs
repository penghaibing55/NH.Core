﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tibos.Domain;
using Tibos.Common;
using Tibos.Repository.Contract;
using Tibos.Service.Contract;
using System.Linq.Expressions;


//Nhibernate Code Generation Template 1.0
//author:Tibos
//blog:www.cnblogs.com/Tibos
//Entity Code Generation Template
namespace Tibos.Service
{
	public class DictService:DictIService
	{
		private readonly IDict dao;
        public DictService(IDict dao)
		{
            this.dao = dao;
        }
		//这个里面是通用方法,实现增删改查排序(动软代码生成器自动生成)
		#region  Method
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dict Get(string id) 
        {
            return dao.Get(id);
        }
        public RequestParams GetWhere(DictRequest request)
        {
        	if (request == null) return null;
            RequestParams rp = new RequestParams();
            //追加查询参数
            if (!string.IsNullOrEmpty(request.Tid))
            {
                rp.Params.Add(new Params() { key = "Tid", value = request.Tid, searchType = EnumBase.SearchType.Eq });
            }
            //添加排序(多个排序条件,可以额外添加)
            if (!string.IsNullOrEmpty(request.sortKey))
            {
                rp.Sort.Add(new Sort() { key = request.sortKey, searchType = (EnumBase.OrderType)request.sortType });
            }
            else
            {
                rp.Sort = null;
            }

            //添加分页
            if (request.pageIndex > 0)
            {
                rp.Paging.pageIndex = request.pageIndex;
                rp.Paging.pageSize = request.pageSize;
            }
            else
            {
                rp.Paging = null;
            }
            return rp;
        }

        public IList<Dict> GetList()
        {
            return dao.LoadAll();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<Dict> GetList(DictRequest request) 
        {
            RequestParams rp = GetWhere(request);
            return dao.GetList(rp);
        }

        public IList<Dict> GetList(Expression<Func<Dict, bool>> expression, List<SortOrder<Dict>> expressionOrder, Pagination pagination)
        {
            return dao.GetList(expression, expressionOrder, pagination);
        }

        /// <summary>
        /// 获取当前条件下的总记录
        /// </summary>
        /// <returns></returns>
        public int GetCount(DictRequest request)
        {
            RequestParams rp = GetWhere(request);
            return dao.GetCount(rp);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="m_user"></param>
        /// <returns></returns>
        public string Save(Dict model) 
        {
             return dao.Save(model).ToString();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="m_user"></param>
        /// <returns></returns>
        public void Update(Dict model) 
        {
            dao.Update(model);
        }

        public void Delete(string id)
        {
            dao.Delete(id);
        }

        public bool Exists(string id) 
        {
            return dao.Exists(id);
        }
		#endregion
      
   
	}
}