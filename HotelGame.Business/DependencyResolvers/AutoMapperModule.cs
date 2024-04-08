using HotelGame.Core.Utilities.IoC;
using HotelGame.DataAccess.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Business.DependencyResolvers
{
    public class AutoMapperModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(
                typeof(BookingProfile),
                typeof(CustomerProfile),
                typeof(HotelPositionProfile),
                typeof(HotelTypeProfile),
                typeof(PlayerHotelPositionProfile),
                typeof(PlayerHotelProfile),
                typeof(PlayerHotelStaffProfile),
                typeof(PlayerRoomMaterialProfile),
                typeof(PlayerRoomProfile),
                typeof(RoomMaterialProfile),
                typeof(RoomTypeProfile),
                typeof(MultiplierProfile),
                typeof(StaffProfile)
                );
        }
    }
}
