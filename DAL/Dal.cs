 

using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
		
	public partial class BlogDal :BaseDal<Blog>,IBlogDal
    {

    }
		
	public partial class BlogTypeDal :BaseDal<BlogType>,IBlogTypeDal
    {

    }
		
	public partial class MessageDal :BaseDal<Message>,IMessageDal
    {

    }
		
	public partial class SingerDal :BaseDal<Singer>,ISingerDal
    {

    }
		
	public partial class SongDal :BaseDal<Song>,ISongDal
    {

    }
		
	public partial class UserInfoDal :BaseDal<UserInfo>,IUserInfoDal
    {

    }
	
}