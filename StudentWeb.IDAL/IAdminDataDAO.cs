﻿
using System.Collections.Generic;
using System.Data;
using StudentWeb.Model;
using StudentWeb.Common;

namespace StudentWeb.IDAL
{
    public partial interface IAdminDataDAO
    {
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="adminData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        int Insert(AdminData adminData, IDbTransaction trans = null);
        
        /// <summary>
		/// 添加多条记录
		/// </summary>
		/// <param name="list">列表</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        int Insert(List<AdminData> list, IDbTransaction trans = null);
        
        /// <summary>
		/// 编辑单条记录
		/// </summary>
		/// <param name="adminData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        int Update(AdminData adminData, IDbTransaction trans = null);
        
        /// <summary>
		/// 编辑多条记录
		/// </summary>
		/// <param name="list">实体列表</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        int Update(List<AdminData> list, IDbTransaction trans = null);
        
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="adminID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        int Delete(int adminID, IDbTransaction trans = null);
        
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="adminData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        int Delete(AdminData adminData, IDbTransaction trans = null);
        
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="adminID">主键</param>
		/// <returns>实体</returns>
        AdminData GetInfo(int adminID);
             
        /// <summary>
		/// 获取列表
		/// </summary>
		/// <returns>实体列表</returns>
        List<AdminData> GetList();
        
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="orderBy">排序规则</param>
        /// <param name="whereClause">条件语句</param>
        /// <returns>分页列表</returns>
        PagedList<AdminData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null);
    }
}
