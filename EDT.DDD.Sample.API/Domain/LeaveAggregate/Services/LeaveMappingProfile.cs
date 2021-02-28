using AutoMapper;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Infrastructure.POs.Leave;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Services
{
    public class LeaveMappingProfile : Profile
    {
        public LeaveMappingProfile()
        {
            // todo: Create Map and ReverseMap between DO and PO for Leave Aggregate
            CreateMap<Leave, LeavePO>().ReverseMap();
            CreateMap<ApprovalInfo, ApprovalInfoPO>().ReverseMap();
        }
    }
}
