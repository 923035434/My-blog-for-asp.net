 
using DAL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
	public partial class DBSession : IDBSession
    {
	
		private IBlogDal _BlogDal;
        public IBlogDal BlogDal
        {
            get
            {
                if(_BlogDal == null)
                {
                    _BlogDal = AbstractFactory.CreateBlogDal();
                }
                return _BlogDal;
            }
            set { _BlogDal = value; }
        }
	
		private IBlogTypeDal _BlogTypeDal;
        public IBlogTypeDal BlogTypeDal
        {
            get
            {
                if(_BlogTypeDal == null)
                {
                    _BlogTypeDal = AbstractFactory.CreateBlogTypeDal();
                }
                return _BlogTypeDal;
            }
            set { _BlogTypeDal = value; }
        }
	
		private IMessageDal _MessageDal;
        public IMessageDal MessageDal
        {
            get
            {
                if(_MessageDal == null)
                {
                    _MessageDal = AbstractFactory.CreateMessageDal();
                }
                return _MessageDal;
            }
            set { _MessageDal = value; }
        }
	
		private ISingerDal _SingerDal;
        public ISingerDal SingerDal
        {
            get
            {
                if(_SingerDal == null)
                {
                    _SingerDal = AbstractFactory.CreateSingerDal();
                }
                return _SingerDal;
            }
            set { _SingerDal = value; }
        }
	
		private ISongDal _SongDal;
        public ISongDal SongDal
        {
            get
            {
                if(_SongDal == null)
                {
                    _SongDal = AbstractFactory.CreateSongDal();
                }
                return _SongDal;
            }
            set { _SongDal = value; }
        }
	
		private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if(_UserInfoDal == null)
                {
                    _UserInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set { _UserInfoDal = value; }
        }
	}	
}