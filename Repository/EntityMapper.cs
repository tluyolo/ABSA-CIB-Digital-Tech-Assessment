using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABSA_CIB_Digital_Tech___Assessment.Models;
using AutoMapper;

namespace ABSA_CIB_Digital_Tech___Assessment.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper( )
        {
          
          //  Mapper.CreateMap<Models.PhoneBookViewModel, PhoneBook>();
            //Mapper.CreateMap<PhoneBook, Models.PhoneBookViewModel>();
        }
        //public TDestination Translate(TSource obj)
        //{
        //    return Mapper.Map<TDestination>(obj);
        //}
    }
}