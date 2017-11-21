using AutoMapper;
using BagiraDanceStudio.Db.Models;
using BagiraDanceStudio.Service.ViewModel;
using MapperExpression = System.Action<AutoMapper.IMapperConfigurationExpression>;

namespace BagiraDanceStudio.Service.AutoMapper
{
    public class UserAutoMapper
    {
        private static bool wasIniti = false;
        public static void Initi()
        {
            if (!wasIniti)
            {
                Mapper.Initialize(UserModelToViewModelMapper());
                Mapper.Initialize(UserModelFromViewModelMapper());
                wasIniti = true;
            }
        }
        public static MapperExpression UserModelToViewModelMapper()
        {
            MapperExpression action = cfg => cfg.CreateMap<User, UserViewModel>()
            .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
            .ForMember(x => x.FName, opt => opt.MapFrom(y => y.PersonData.FName))
            .ForMember(x => x.LName, opt => opt.MapFrom(y => y.PersonData.LName))
            .ForMember(x => x.Email, opt => opt.MapFrom(y => y.PersonData.Email))
            .ForMember(x => x.Phone, opt => opt.MapFrom(y => y.PersonData.Phone))
            .ForMember(x => x.Photo, opt => opt.MapFrom(y => y.PersonData.Photo))
            .ForMember(x => x.AdditionalInformaion, opt => opt.MapFrom(y => y.PersonData.AdditionalInformaion))
            .ForMember(x => x.Login, opt => opt.MapFrom(y => y.PersonData.Login))
            .ForMember(x => x.HashedPassword, opt => opt.MapFrom(y => y.PersonData.HashedPassword))

            .ForMember(x => x.Role_Name, opt => opt.MapFrom(y => y.PersonData.Role.Name))
            .ForMember(x => x.Role_Priority, opt => opt.MapFrom(y => y.PersonData.Role.Priority))

            .ForMember(x => x.IdManager, opt => opt.MapFrom(y => y.Manager.Id))
            .ForMember(x => x.FName_Manager, opt => opt.MapFrom(y => y.Manager.PersonData.FName))
            .ForMember(x => x.LName_Manager, opt => opt.MapFrom(y => y.Manager.PersonData.LName))
            .ForMember(x => x.Email_Manager, opt => opt.MapFrom(y => y.Manager.PersonData.Email))
            .ForMember(x => x.Phone_Manager, opt => opt.MapFrom(y => y.Manager.PersonData.Phone))

            .ForMember(x => x.IdBillingHistory, opt => opt.MapFrom(y => y.BillingHistory.Id))
            .ForMember(x => x.TrainingPoints, opt => opt.MapFrom(y => y.TrainingPoints))
            .ForMember(x => x.Balance, opt => opt.MapFrom(y => y.Balance));

            return action;
        }
        public static MapperExpression UserModelFromViewModelMapper()
        {
            MapperExpression action = cfg => cfg.CreateMap<UserViewModel, User>()
            .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
            .ForMember(x => x.PersonData.FName, opt => opt.MapFrom(y => y.FName))
            .ForMember(x => x.PersonData.LName, opt => opt.MapFrom(y => y.LName))
            .ForMember(x => x.PersonData.Email, opt => opt.MapFrom(y => y.Email))
            .ForMember(x => x.PersonData.Phone, opt => opt.MapFrom(y => y.Phone))
            .ForMember(x => x.PersonData.Photo, opt => opt.MapFrom(y => y.Photo))
            .ForMember(x => x.PersonData.AdditionalInformaion, opt => opt.MapFrom(y => y.AdditionalInformaion))
            .ForMember(x => x.PersonData.Login, opt => opt.MapFrom(y => y.Login))
            .ForMember(x => x.PersonData.HashedPassword, opt => opt.MapFrom(y => y.HashedPassword))

            .ForMember(x => x.PersonData.Role.Name, opt => opt.MapFrom(y => y.Role_Name))
            .ForMember(x => x.PersonData.Role.Priority, opt => opt.MapFrom(y => y.Role_Priority))

            .ForMember(x => x.Manager.Id, opt => opt.MapFrom(y => y.IdManager))
            .ForMember(x => x.Manager.PersonData.FName, opt => opt.MapFrom(y => y.FName_Manager))
            .ForMember(x => x.Manager.PersonData.LName, opt => opt.MapFrom(y => y.LName_Manager))
            .ForMember(x => x.Manager.PersonData.Email, opt => opt.MapFrom(y => y.Email_Manager))
            .ForMember(x => x.Manager.PersonData.Phone, opt => opt.MapFrom(y => y.Phone_Manager))

            .ForMember(x => x.BillingHistory.Id, opt => opt.MapFrom(y => y.IdBillingHistory))
            .ForMember(x => x.TrainingPoints, opt => opt.MapFrom(y => y.TrainingPoints))
            .ForMember(x => x.Balance, opt => opt.MapFrom(y => y.Balance));

            return action;
        }
    }
}
