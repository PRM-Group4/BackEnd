using AutoMapper;
using BOs.Models;
using Services.Modal.Request;


namespace KoiAPI.AppStarts
{
	public class AutoMapperConfig : Profile
	{
        public AutoMapperConfig()
        {
            CreateMap<UserRequest, User>().ReverseMap();
            CreateMap<FarmRequest, Farm>().ReverseMap();
            CreateMap<KoiTypeRequest, KoiType>().ReverseMap();
            CreateMap<OrderRequest, Order>().ReverseMap();
            CreateMap<PaymentRequest, Payment>().ReverseMap();
            CreateMap<QuotationRequest, Quotation>().ReverseMap();
            CreateMap<ReportRequest, Report>().ReverseMap();
            CreateMap<RoleRequest, Role>().ReverseMap();
            CreateMap<ServiceRequestDTO, ServiceRequest>().ReverseMap();
            CreateMap<TripRequestDTO, Trip>().ReverseMap();

        }


    }
}
