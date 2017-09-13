 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
	public partial interface IDBSession
    {

	
		IBlogDal BlogDal{get;set;}
	
		IBlogSettingDal BlogSettingDal{get;set;}
	
		IBlogTypeDal BlogTypeDal{get;set;}
	
		IM_BgImgDal M_BgImgDal{get;set;}
	
		IMessageDal MessageDal{get;set;}
	
		ISingerDal SingerDal{get;set;}
	
		ISongDal SongDal{get;set;}
	
		IUserInfoDal UserInfoDal{get;set;}
	}	
}