 

using IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public static partial class AbstractFactory
    {
      
   
		
	    public static IBlogDal CreateBlogDal()
        {

		 string fullClassName = nameSpace + ".BlogDal";
          return CreateInstance(fullClassName) as IBlogDal;

        }
		
	    public static IBlogSettingDal CreateBlogSettingDal()
        {

		 string fullClassName = nameSpace + ".BlogSettingDal";
          return CreateInstance(fullClassName) as IBlogSettingDal;

        }
		
	    public static IBlogTypeDal CreateBlogTypeDal()
        {

		 string fullClassName = nameSpace + ".BlogTypeDal";
          return CreateInstance(fullClassName) as IBlogTypeDal;

        }
		
	    public static IM_BgImgDal CreateM_BgImgDal()
        {

		 string fullClassName = nameSpace + ".M_BgImgDal";
          return CreateInstance(fullClassName) as IM_BgImgDal;

        }
		
	    public static IMessageDal CreateMessageDal()
        {

		 string fullClassName = nameSpace + ".MessageDal";
          return CreateInstance(fullClassName) as IMessageDal;

        }
		
	    public static ISingerDal CreateSingerDal()
        {

		 string fullClassName = nameSpace + ".SingerDal";
          return CreateInstance(fullClassName) as ISingerDal;

        }
		
	    public static ISongDal CreateSongDal()
        {

		 string fullClassName = nameSpace + ".SongDal";
          return CreateInstance(fullClassName) as ISongDal;

        }
		
	    public static IUserInfoDal CreateUserInfoDal()
        {

		 string fullClassName = nameSpace + ".UserInfoDal";
          return CreateInstance(fullClassName) as IUserInfoDal;

        }
	}
	
}