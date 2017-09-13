 
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
   
	
	public partial interface IBlogDal :IBaseDal<Blog>
    {
      
    }
	
	public partial interface IBlogSettingDal :IBaseDal<BlogSetting>
    {
      
    }
	
	public partial interface IBlogTypeDal :IBaseDal<BlogType>
    {
      
    }
	
	public partial interface IM_BgImgDal :IBaseDal<M_BgImg>
    {
      
    }
	
	public partial interface IMessageDal :IBaseDal<Message>
    {
      
    }
	
	public partial interface ISingerDal :IBaseDal<Singer>
    {
      
    }
	
	public partial interface ISongDal :IBaseDal<Song>
    {
      
    }
	
	public partial interface IUserInfoDal :IBaseDal<UserInfo>
    {
      
    }
	
}