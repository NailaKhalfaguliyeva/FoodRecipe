﻿using Core.DataAcces.Concrete;
using DataAcess.Abstract;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.TableModels;

namespace DataAcess.Concrete
{
    public class AboutRightContentDal : BaseRepository<AboutRightContent, AppDbcontext>, IAboutRightContentDal
    {
    }

   
}
