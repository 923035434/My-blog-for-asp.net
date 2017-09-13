 

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
	
	public partial interface IBlogService : IBaseService<Blog>
    {
       
    }   
	
	public partial interface IBlogSettingService : IBaseService<BlogSetting>
    {
       
    }   
	
	public partial interface IBlogTypeService : IBaseService<BlogType>
    {
       
    }   
	
	public partial interface IM_BgImgService : IBaseService<M_BgImg>
    {
       
    }   
	
	public partial interface IMessageService : IBaseService<Message>
    {
       
    }   
	
	public partial interface ISingerService : IBaseService<Singer>
    {
       
    }   
	
	public partial interface ISongService : IBaseService<Song>
    {
       
    }   
	
	public partial interface IUserInfoService : IBaseService<UserInfo>
    {
       
    }   
	
}