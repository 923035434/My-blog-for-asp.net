 
using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	
	public partial class BlogService :BaseService<Blog>,IBlogService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.BlogDal;
        }
    }   
	
	public partial class BlogSettingService :BaseService<BlogSetting>,IBlogSettingService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.BlogSettingDal;
        }
    }   
	
	public partial class BlogTypeService :BaseService<BlogType>,IBlogTypeService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.BlogTypeDal;
        }
    }   
	
	public partial class M_BgImgService :BaseService<M_BgImg>,IM_BgImgService
    {    
		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.M_BgImgDal;
        }
    }   
	
	public partial class MessageService :BaseService<Message>,IMessageService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.MessageDal;
        }
    }   
	
	public partial class SingerService :BaseService<Singer>,ISingerService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.SingerDal;
        }
    }   
	
	public partial class SongService :BaseService<Song>,ISongService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.SongDal;
        }
    }   
	
	public partial class UserInfoService :BaseService<UserInfo>,IUserInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.UserInfoDal;
        }
    }   
	
}