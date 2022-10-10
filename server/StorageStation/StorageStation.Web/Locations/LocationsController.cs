using AutoMapper;
using MediatR;
using StorageStation.Web.Common.Controllers;

namespace StorageStation.Web.Locations;

public class LocationsController : BaseApiController
{
    public LocationsController(IMediator mediator, IMapper mapper) 
        : base(mediator, mapper)
    {
    }
}