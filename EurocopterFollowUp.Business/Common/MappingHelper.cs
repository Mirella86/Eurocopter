using System.Collections.Generic;
using AutoMapper;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.Model.ViewModels;


namespace EurocopterFollowUp.Business.Common
{
    public static class MappingHelper
    {
        public static void CreateMappings()
        {
            Mapper.CreateMap<Item, ItemViewModel>()
                .ForMember(i => i.Status, member => member.Ignore())
                .ForMember(i => i.Author, member => member.Ignore())
                .ForMember(i => i.ProofReader, member => member.Ignore());
            Mapper.CreateMap<ItemViewModel, Item>()
                  .ForSourceMember(i => i.Status, member => member.Ignore())
                  .ForSourceMember(i => i.Author, member => member.Ignore())
                  .ForSourceMember(i => i.ProofReader, member => member.Ignore())
                  .ForMember(i => i.Status, member => member.Ignore());


            Mapper.CreateMap<GridState, GridStateViewModel>();
            Mapper.CreateMap<GridStateViewModel, GridState>();

            Mapper.CreateMap<ApplicationRole, ApplicationRoleViewModel>();
            Mapper.CreateMap<ApplicationRoleViewModel, ApplicationRole>();

            Mapper.CreateMap<vw_UserDetails, UserDetailViewModel>();
            Mapper.CreateMap<UserDetailViewModel, vw_UserDetails>();
        }

        public static IEnumerable<TD> MapIEnumerable<TS, TD>(this IEnumerable<TS> items)
        {
            return Mapper.Map<IEnumerable<TS>, IEnumerable<TD>>(items);
        }

        public static T MapTo<T>(this object obj)
        {
            if (obj == null)
            {
                return default(T);
            }

            return Mapper.Map<object, T>(obj);
        }
    }
}